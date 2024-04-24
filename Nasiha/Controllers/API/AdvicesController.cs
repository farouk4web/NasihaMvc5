//using Microsoft.AspNet.Identity;
//using Nasiha.DTOs;
//using Nasiha.Models;
//using System;
//using System.Linq;

//namespace Nasiha.Controllers
//{
//    [Authorize]
//    public class AdvicesController : ApiController
//    {
//        private ApplicationDbContext _context = new ApplicationDbContext();
//        private readonly int advicesPerRequest = 15;

//        [Authorize(Roles = RoleName.OwnersAndAdmins)]
//        [HttpGet]
//        public IHttpActionResult GetAll(int pageNumber = 1)
//        {
//            var allAdvices = _context.Advices
//                                        .OrderBy(a => a.Id)
//                                        .Skip((pageNumber - 1) * advicesPerRequest)
//                                        .Take(advicesPerRequest)
//                                        .ToList();

//            var advicesDto = allAdvices.Select(a => new AdviceDto
//            {
//                Id = a.Id,
//                Content = a.Content,
//                PublishedDate = a.PublishedDate,
//                LikeIt = a.LikeIt,
//                PinIt = a.PinIt,
//                Sender = a.Sender,

//                ReceiverId = a.ReceiverId,
//                Receiver = new UserDto
//                {
//                    Email = a.Receiver.Email,
//                    FullName = a.Receiver.FullName,
//                    Nickname = a.Receiver.Nickname,
//                    ProfileImageSrc = a.Receiver.ProfileImageSrc
//                }
//            });

//            return Ok(advicesDto);
//        }

//        [HttpGet]
//        [Route("api/UserAdvices")]
//        public IHttpActionResult UserAvices(string id, int pageNumber = 1)
//        {
//            var userAdvices = _context.Advices
//                                        .Where(a => a.ReceiverId == id)
//                                        .OrderBy(a => a.Id)
//                                        .Skip((pageNumber - 1) * advicesPerRequest)
//                                        .Take(advicesPerRequest)
//                                        .ToList();

//            var userAdvicesDto = userAdvices.Select(a => new AdviceDto
//            {
//                Id = a.Id,
//                Content = a.Content,
//                PublishedDate = a.PublishedDate,
//                LikeIt = a.LikeIt,
//                PinIt = a.PinIt,
//                Sender = a.Sender,
//                ReceiverId = a.ReceiverId
//            });

//            return Ok(userAdvicesDto);
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public IHttpActionResult AddNewAdvice(AdviceDto dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var currentUserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : null;
//            // check if he try to send a message to him self
//            if (dto.ReceiverId == currentUserId)
//                return BadRequest("you are traying to send message to your self");

//            Advice newAdvice = new Advice
//            {
//                Content = dto.Content,
//                PublishedDate = DateTime.UtcNow,
//                ReceiverId = dto.ReceiverId,
//                Sender = dto.Sender
//            };

//            _context.Advices.Add(newAdvice);
//            _context.SaveChanges();

//            return Ok();
//        }

//        // add like To Advice Or remove it
//        [HttpPost]
//        [Route("api/LikeOrNot")]
//        public IHttpActionResult LikeOrNot(ActionDto dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var adviceInDb = _context.Advices.Find(dto.AdviceId);
//            adviceInDb.LikeIt = dto.AddOrNot;

//            _context.SaveChanges();

//            return Ok();
//        }

//        // pin Advice Or not
//        [HttpPost]
//        [Route("api/PinOrNot")]
//        public IHttpActionResult PinOrNot(ActionDto dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var adviceInDb = _context.Advices.Find(dto.AdviceId);
//            adviceInDb.PinIt = dto.AddOrNot;

//            _context.SaveChanges();

//            return Ok();
//        }

//        [HttpDelete]
//        public IHttpActionResult Delete(int id)
//        {
//            Advice adviceInDb = _context.Advices.Find(id);
//            if (adviceInDb == null)
//                return NotFound();

//            if (adviceInDb.ReceiverId == User.Identity.GetUserId() || User.IsInRole(RoleName.Admins) || User.IsInRole(RoleName.Owners))
//            {
//                _context.Advices.Remove(adviceInDb);
//                _context.SaveChanges();
//            }

//            return Ok();
//        }
//    }
//}
