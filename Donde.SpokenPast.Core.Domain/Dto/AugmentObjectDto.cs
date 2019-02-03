using Donde.SpokenPast.Core.Domain.Models;

namespace Donde.SpokenPast.Core.Domain.Dto
{
    /// <summary>
    /// This class stores any extra information we want to transfer along with augment main object.
    /// </summary>
    public class AugmentObjectDto : AugmentObject
    {
        public double Distance { get; set; }
    }
}
