using System.Collections.Generic;
using Donde.SpokenPast.Core.Domain.Models;

namespace Donde.SpokenPast.Core.Domain.DataBuilder
{
    public class BaseDataBuilder
    {
        public List<AugmentObject> AugmentObjects { get; set; } = new List<AugmentObject>();
    }
}
