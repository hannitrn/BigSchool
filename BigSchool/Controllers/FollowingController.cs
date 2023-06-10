using _2011770131_Trần_Hân_Nhi_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2011770131_Trần_Hân_Nhi_BigSchool.Controllers
{
    public class FollowingController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Follow(Following follow)
        {
            //user login người theo dõi, follow.followeeid người được theo dõi
            var userID = User.Identity.GetUserId();
            if (userID == null)
                return BadRequest("Please login first!");
            if (userID == follow.FolloweeId)
                return BadRequest("Can not follow myself");

            BigSchoolContext context = new BigSchoolContext();
            //kiểm tra mã userId đã được theo dõi chưa
            Following find = context.Following.FirstOrDefault(p => p.FollowerId == userID && p.FolloweeId == follow.FolloweeId);
            if (find != null)
            {
                //return BadRequest("The already following exists!");
                context.Following.Remove(context.Following.SingleOrDefault(p => p.FollowerId == userID && p.FolloweeId == follow.FolloweeId));
                context.SaveChanges();
                return Ok("cancel");
            }

            follow.FollowerId = userID;
            context.Following.Add(follow);
            context.SaveChanges();
            return Ok();
        }
    }
}
