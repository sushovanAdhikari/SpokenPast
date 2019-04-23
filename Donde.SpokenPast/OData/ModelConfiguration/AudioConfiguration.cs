﻿using Donde.SpokenPast.Web.ViewModels;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Donde.SpokenPast.Web.OData.ModelConfiguration
{
    public class AudioConfiguration : IModelConfiguration
    {
        private void ConfigureV1(ODataModelBuilder builder)
        {
            var release = ConfigureCurrent(builder);
        }

        private EntityTypeConfiguration<AudioViewModel> ConfigureCurrent(ODataModelBuilder builder)
        {
            var user = builder.EntitySet<AudioViewModel>("audios").EntityType;
            return user;
        }

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            switch (apiVersion.MajorVersion)
            {
                case 1:
                    ConfigureV1(builder);
                    break;
                default:
                    ConfigureCurrent(builder);
                    break;
            }
        }
    }
}