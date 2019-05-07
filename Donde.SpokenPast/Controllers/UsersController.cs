using AutoMapper;
using AutoMapper.QueryableExtensions;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Donde.SpokenPast.Web.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Web.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Users")]
    public class UsersController : ODataController
    {
        private readonly DondeContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
       // private readonly object odataOptions;

        public UsersController(DondeContext context, IUserService userService, IMapper mapper)
        {


            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ODataRoute]
        public async Task<IEnumerable<UserViewModel>> Get(ODataQueryOptions odataOptions)
        {
            var result = new List<UserViewModel>();
            var audiosQueryable = _userService.GetUsers();

            var projectedAudios = audiosQueryable.ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);

            var appliedResults = odataOptions.ApplyTo(projectedAudios);

            var audioViewModels = appliedResults as IQueryable<UserViewModel>;

            if (audioViewModels != null)
            {
                result = await audioViewModels.ToListAsync();
            }

            return result;
        }

        //[HttpGet]
        //[ODataRoute("{Id}")]
        //public async Task<IActionResult> Get([FromODataUri]Guid id)
        //{

        //   var result = await _userService.GetUserById(id);

        //    var mappedResult = _mapper.Map<List<UserViewModel>>(result);

        //    return Ok(result);
        //}

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> Post([FromBody]UserViewModel user)
        {
            var userModel = _mapper.Map<User>(user);
            UserValidator validationUser = new UserValidator();
            ValidationResult results = validationUser.Validate(userModel);
            String errors = "";
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    errors += error.ErrorMessage + "   ";
                }

                return new JsonResult(new { Errors = errors });
            }
            var returnUser = await _userService.CreateUserAsync(userModel);
            if (returnUser.Email == null) {
                return new JsonResult(new { Errors = "User with the email has already been registered." });
            }
            return Ok(returnUser);
        }

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> Authenticate([FromBody]UserViewModel user)
        {
            if (_userService.DoesUserNotExist(user.Email))
            {
                return new JsonResult(new { Errors = "The email you have entered is not registered.", Success = false });
            }
            var getUser = await _userService.AuthenticateUser(user.Email, user.Password);
            
            if (getUser.Email == null)
            {
                return new JsonResult(new { Errors = "Email and password does not match", Success = false });
            }
            return new JsonResult(new { Id = getUser.Id, Success = true});
        }

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> Put([FromBody]UserViewModel user)
        {
            // on put, take same viewmodel, use same mapper,
            // and on the service layer, change the updated date.
            var userModel = _mapper.Map<User>(user);
            return Ok(await _userService.CreateUserAsync(userModel));
        }

        [HttpGet]
        [ODataRoute]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var userToEdit = await _userService.GetUserByIdAsync(id);
            return new JsonResult(new { User= userToEdit });
        }

        [HttpPost]
        [ODataRoute]
        public IActionResult UpdateUser([FromBody]User entity)
        {
            _userService.UpdateUserAsync(entity.Id, entity);

            return new JsonResult(new { Message = "User has been successfully updated" });
        }

        //    var result = await _userService.CreateUserAsync(entity);

        //    //var mappedResult = _mapper.Map<List<UserViewModel>>(result);

        //    return Ok(result);
        //}
        ///*
        // * 
        // * 
        // * 
        // * 
        // * 
        // * 
        // * 
        // * 
        //// GET: Users/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// GET: Users/Create
        //[HttpPost, ActionName("Create")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Phone,OrganizationId,AddedDate,UpdatedDate,IsActive")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        user.Id = Guid.NewGuid();
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Password,Phone,OrganizationId,AddedDate,UpdatedDate,IsActive")] User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //[HttpDelete]
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserExists(Guid id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
        //*/
    }
}
