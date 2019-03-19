using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Donde.SpokenPast.Web.ViewModels;

namespace Donde.SpokenPast.Web.Controller
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("augmentObjects")]
    public class UserController : ODataController
    {
        private readonly IUsersServices _UsersServices;
        private readonly IMapper _mapper;

        public UserController(IUsersServices userServices, IMapper mapper)
        {
            _UsersServices = userServices;
            _mapper = mapper;
        }

        [HttpGet()]
        [ODataRoute]
        public async Task<IActionResult> GetUser(ODataQueryOptions<UserViewModel> options, Guid id)
        {
            var result = await _UsersServices.GetUserById(id);

            var mappedResult = _mapper.Map<List<UserViewModel>>(result);

            return Ok(result);
        }
    }
}