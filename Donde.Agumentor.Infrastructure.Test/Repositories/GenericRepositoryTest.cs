using System;
using System.Linq;
using System.Threading.Tasks;
using Donde.SpokenPast.Core.Domain.DataBuilder;
using Donde.SpokenPast.Core.Domain.Helpers;
using Donde.SpokenPast.Core.Domain.Interfaces;
using Donde.SpokenPast.Core.Domain.Models;
using Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces;
using Donde.SpokenPast.Infrastructure.Database;
using Donde.SpokenPast.Infrastructure.DataBuilder;
using Donde.SpokenPast.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Donde.SpokenPast.Infrastructure.Test.Repositories
{
    [TestClass]
    public class GenericRepositoryTest : BaseTest
    {
        [TestMethod]
        public void GetAll_ReturnsIQueryableOfEntity()
        {
            using (var context = GetDondeContext())
            {
                new DondeSpokenPastDataBuilder_AugmentObject().AddAugmentObject().ApplyTo(context);

                var defaultRepository = DefaultGenericRepository<AugmentObject>(context);

                var result = defaultRepository.GetAll();

                result.ShouldNotBeNull();
                result.ShouldBeAssignableTo<IQueryable<AugmentObject>>();
                result.Count().ShouldBe(1);
            }
        }

        [TestMethod]
        public void GetAll_WithNoResult_ReturnsIQueryableOfEmptyEntity()
        {
            using (var context = GetDondeContext())
            {           
                var defaultRepository = DefaultGenericRepository<AugmentObject>(context);

                var result = defaultRepository.GetAll();

                result.ShouldNotBeNull();
                result.ShouldBeAssignableTo<IQueryable<AugmentObject>>();
                result.Count().ShouldBe(0);
            }
        }

        [TestMethod]
        public async Task GetByIdAsync_WithMatchingId_ReturnsEntity()
        {
            using (var context = GetDondeContext())
            {
                var augmentObjectId = SequentialGuidGenerator.GenerateComb();
                var audioId = SequentialGuidGenerator.GenerateComb();

                var dataBuilder = new DondeSpokenPastDataBuilder_AugmentObject();
                dataBuilder
                    .AddAugmentObject(dataBuilder.MakeAugmentObject(augmentObjectId, audioId: audioId))
                    .ApplyTo(context);

                var defaultRepository = DefaultGenericRepository<AugmentObject>(context);

                var result = await defaultRepository.GetByIdAsync(augmentObjectId);

                result.ShouldNotBeNull();
                result.AudioId.ShouldBe(audioId);                        
            }
        }

        [TestMethod]
        public async Task GetByIdAsync_WithNoMatchingId_ReturnsEmptyEntity()
        {
            using (var context = GetDondeContext())
            {
                var augmentObjectId = SequentialGuidGenerator.GenerateComb();
                var audioId = SequentialGuidGenerator.GenerateComb();

                var dataBuilder = new DondeSpokenPastDataBuilder_AugmentObject();
                dataBuilder
                    .AddAugmentObject(dataBuilder.MakeAugmentObject(augmentObjectId, audioId: audioId))
                    .ApplyTo(context);

                var defaultRepository = DefaultGenericRepository<AugmentObject>(context);

                var result = await defaultRepository.GetByIdAsync(SequentialGuidGenerator.GenerateComb());

                result.ShouldBeNull();
            }
        }

        [TestMethod]
        public async Task UpdateAsync_WithValidEntity_AddsEntity()
        {
            using (var context = GetDondeContext())
            {
                var augmentObjectId = SequentialGuidGenerator.GenerateComb();
                var audioId = SequentialGuidGenerator.GenerateComb();

                var dataBuilder = new DondeSpokenPastDataBuilder_AugmentObject();
                var augmentObject = dataBuilder.MakeAugmentObject(augmentObjectId, audioId: audioId);
                dataBuilder
                    .AddAugmentObject(augmentObject)
                    .ApplyTo(context);

                var updatedObject = new AugmentObject
                {
                    Id = augmentObjectId,
                    UpdatedDate = DateTime.Parse("2018/01/28")
                };

                var defaultRepository = DefaultGenericRepository<AugmentObject>(context);

                var result = await defaultRepository.UpdateAsync(augmentObjectId, updatedObject);

                result.ShouldNotBeNull();
                var updatedEntity = context.AugmentObjects.FirstOrDefault(x => x.Id == augmentObjectId);

                updatedEntity.ShouldNotBeNull();
                updatedEntity.UpdatedDate.ShouldBe(DateTime.Parse("2018/01/28"));
            }
        }

        [TestMethod]
        public async Task CreateAsync_WithValidEntity_AddsEntity()
        {
            using (var context = GetDondeContext())
            {
                var augmentObjectId = SequentialGuidGenerator.GenerateComb();
                var audioId = SequentialGuidGenerator.GenerateComb();

                var dataBuilder = new DondeSpokenPastDataBuilder_AugmentObject();
                var newAugmentObject = dataBuilder.MakeAugmentObject(augmentObjectId, audioId: audioId);

                var defaultRepository = DefaultGenericRepository<AugmentObject>(context);

                var result = await defaultRepository.CreateAsync(newAugmentObject);

                result.ShouldNotBeNull();
                context.AugmentObjects.Count().ShouldBe(1);
            }
        }

        private IGenericRepository<T> DefaultGenericRepository<T>(DondeContext dbContext) where T : class, IDondeModel
        {
            return new GenericRepository<T>(dbContext);
        }
    }
}
