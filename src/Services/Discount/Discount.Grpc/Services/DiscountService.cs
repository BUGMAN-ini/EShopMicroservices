using Discound.Grpc;
using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbcontext, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            //TODO: GetDiscound from Database
            var coupon = await dbcontext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon is null)
                coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Description"  };

            logger.LogInformation("Coupon is retrieved for : {ProductName}", coupon.ProductName);

            var couponmodel = coupon.Adapt<CouponModel>();

            return couponmodel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if(coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Coupon is not found"));
            
            dbcontext.Coupons.Add(coupon);
            await dbcontext.SaveChangesAsync();

            logger.LogInformation("Coupon is successfully created. ProductName: {ProductName}", coupon.ProductName);

            return coupon.Adapt<CouponModel>();
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Coupon is not found"));

            dbcontext.Coupons.Update(coupon);
            await dbcontext.SaveChangesAsync();

            logger.LogInformation("Coupon is successfully Updated. ProductName: {ProductName}", coupon.ProductName);

            return coupon.Adapt<CouponModel>(); 
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbcontext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Coupon is not found"));

            dbcontext.Coupons.Remove(coupon);
            await dbcontext.SaveChangesAsync();

            logger.LogInformation("Succesfully Deleted {ProductName}", request.ProductName);
            return new DeleteDiscountResponse { Success = true };

        }
    }
}
