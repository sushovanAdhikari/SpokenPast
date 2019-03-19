using AutoMapper;
using Donde.SpokenPast.Core.Service.Interfaces.ServiceInterfaces;
using Donde.SpokenPast.Web.ViewModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Web.Controller
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("augmentObjects")]
    public class AugmentObjectController : ODataController
    {
        private readonly IAugmentObjectService _augmentObjectService;
        private readonly IMapper _mapper;

        public AugmentObjectController(IAugmentObjectService augmentObjectService, IMapper mapper)
        {
            _augmentObjectService = augmentObjectService;
            _mapper = mapper;
        }


        [HttpGet()]
        [ODataRoute]
        public async Task<IActionResult> GetAugmentObject(ODataQueryOptions<AugmentObjectViewModel> options, double latitude,
            double longitude,
            int radiusInMeters)
        {
            var result = await _augmentObjectService.GetClosestAugmentObjectsByRadius(latitude, longitude, radiusInMeters);

            var mappedResult = _mapper.Map<List<AugmentObjectViewModel>>(result);

            return Ok(mappedResult);
        }

    }
}
