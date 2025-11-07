using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Yr25Mango.Services.CouponAPI.Data;
using Yr25Mango.Services.CouponAPI.Models;
using Yr25Mango.Services.CouponAPI.Models.DTO;

namespace Yr25Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _responseDTO;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db,
            IMapper mapper)
        {
            _db = db;
            _responseDTO=new ResponseDTO();
            _mapper=mapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();


                _responseDTO.Result= _mapper.Map<IEnumerable<CouponDTO>>(objList);

                return _responseDTO;
            }
            catch(Exception ex)
            {
                _responseDTO.IsSuccess=false;
                _responseDTO.Message=ex.Message;
            }
            return _responseDTO;

        }

        [HttpGet("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                
                 
                _responseDTO.Result= _mapper.Map<CouponDTO>(obj);
                return _responseDTO;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;

        }


        [HttpGet("GetByCode/{code}")]
        public ResponseDTO Get(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());



                _responseDTO.Result = _mapper.Map<CouponDTO>(obj);
                return _responseDTO;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;

        }


        [HttpPost]
        public ResponseDTO Post([FromBody] CouponDTO couponDTO)
        {
            try
            {

                _db.Coupons.Add(_mapper.Map<Coupon>(couponDTO));
                _db.SaveChanges();

                _responseDTO.Result = _mapper.Map<CouponDTO>(couponDTO);
                return _responseDTO;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;

        }


        [HttpPut]
        public ResponseDTO Put([FromBody] CouponDTO couponDTO)
        {
            try
            {

                _db.Coupons.Update(_mapper.Map<Coupon>(couponDTO));
                _db.SaveChanges();

                _responseDTO.Result = _mapper.Map<CouponDTO>(couponDTO);
                return _responseDTO;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;

        }


        [HttpDelete]
        public ResponseDTO Delete(int id)
        {
            try
            {

                Coupon obj = _db.Coupons.First(u => u.CouponId == id);

                _db.Coupons.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.Message = ex.Message;
            }
            return _responseDTO;

        }

    }
}
