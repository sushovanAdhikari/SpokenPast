using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Infrastructure.Database;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData;
using Donde.SpokenPast.Core.Services.Services;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using AutoMapper;
using Donde.SpokenPast.Web.ViewModels;

namespace Donde.SpokenPast.Web.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Users")]
    public class UsersController : ODataController
    {
        private readonly DondeContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(DondeContext context, IUserService userService, IMapper mapper)
        {


            _context = context;
            _userService = userService;
            _mapper = mapper;
        }
            
        [HttpGet]
        [ODataRoute]
        public async Task<IActionResult> Get()
        {

            var result = await _userService.GetUsersAsync();

            var mappedResult = _mapper.Map<List<UserViewModel>>(result);

            return Ok(result);
        }

        [HttpGet]
        [ODataRoute("{Id}")]
        public async Task<IActionResult> Get([FromODataUri]Guid id)
        {

           var result = await _userService.GetUserById(id);

            var mappedResult = _mapper.Map<List<UserViewModel>>(result);

            return Ok(result);
        }

        [HttpPost]
        [ODataRoute]
        public async Task<IActionResult> Post([FromODataUri]String name,[FromODataUri]String password, [FromODataUri]String email, [FromODataUri] String phone)
        {
            User entity = new User
            {
                Name = name,
                Password = password,
                Email = email,
                Phone = phone,

            };

            var result = await _userService.CreateUserAsync(entity);

            //var mappedResult = _mapper.Map<List<UserViewModel>>(result);

            return Ok(result);
        }
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        [HttpPost, ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Phone,OrganizationId,AddedDate,UpdatedDate,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Password,Phone,OrganizationId,AddedDate,UpdatedDate,IsActive")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        */
    }
}
