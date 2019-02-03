using System;
using System.Collections.Generic;
using System.Text;
using Donde.SpokenPast.Core.Domain.DataBuilder;
using Donde.SpokenPast.Infrastructure.Database;

namespace Donde.SpokenPast.Infrastructure.DataBuilder
{
    public static class DondeDataBuilderExtension
    {
        public static void ApplyTo(this DondeSpokenPastDataBuilder_AugmentObject builder, DondeContext context)
        {
            context.AugmentObjects.AddRange(builder.AugmentObjects);
            context.SaveChanges();
        }
    }
}
