using Donde.SpokenPast.Core.Domain.Helpers;
using Donde.SpokenPast.Core.Domain.Models;
using System;

namespace Donde.SpokenPast.Core.Domain.DataBuilder
{
    public partial class DondeSpokenPastDataBuilder_AugmentObject : BaseDataBuilder
    {
        public DondeSpokenPastDataBuilder_AugmentObject AddAugmentObject(AugmentObject augmentObject = null)
        {
            AugmentObjects.Add(augmentObject ?? MakeAugmentObject());

            return this;
        }

        public AugmentObject MakeAugmentObject
        (Guid? id = null,
            Guid? avatarId = null,
            Guid? audioId = null,
            Guid? augmentImageId = null,
            string description = null,
            double? latitude = null,
            double? longitude = null)
        {
            return new AugmentObject
            {
                Id = id ?? SequentialGuidGenerator.GenerateComb(),
                AvatarId = avatarId ?? SequentialGuidGenerator.GenerateComb(),
                AudioId = audioId ?? SequentialGuidGenerator.GenerateComb(),
                AugmentImageId = augmentImageId ?? SequentialGuidGenerator.GenerateComb(),
                Description = description ?? "Test Description",
                Latitude = latitude ?? 30.65456,
                Longitude = longitude ?? 45.2445
            };
        }
    }
}
