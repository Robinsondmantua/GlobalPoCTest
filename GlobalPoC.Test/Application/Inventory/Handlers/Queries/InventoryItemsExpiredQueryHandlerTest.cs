using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Queries.Handlers;
using Application.Features.Inventory.Queries.Request;
using Application.Mapping;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GlobalPoC.Test.Application.Inventory.Handlers.Queries
{
    public class InventoryItemsExpiredQueryHandlerTest
    {
        private readonly Mock<IQueryRepository<Domain.Aggregate.Inventory>> _inventoryQueryRepository = new Mock<IQueryRepository<Domain.Aggregate.Inventory>>();
        private readonly IMapper _mapper;
        private readonly Mock<IEventNotificationService> _eventNotificationService = new Mock<IEventNotificationService>();
        private readonly InventoryItemsExpiredQueryHandler _cut;

        public InventoryItemsExpiredQueryHandlerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InventoryMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();

            _cut = new InventoryItemsExpiredQueryHandler(_inventoryQueryRepository.Object, _mapper);
        }

        [Fact]
        public async Task HandleMethod_WhenInventoryHasNotFound_ShouldReturnNotFoundException()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<InventoryItemExpiredQueryRequest>();

            _inventoryQueryRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Domain.Aggregate.Inventory>(null));

            //Act
            Func<Task> act = () => _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<NotFoundException>().WithMessage("Inventory not found");
        }
    }
}
