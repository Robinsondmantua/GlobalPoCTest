using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Commands.Request;
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

namespace Test.Application.Inventory
{
    /// <summary>
    /// Unit test for InventorySingleQueryHandler class
    /// </summary>
    public class InventorySingleQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IQueryRepository<Domain.Aggregate.Inventory>> _inventoryQueryRepository = new Mock<IQueryRepository<Domain.Aggregate.Inventory>>();
        private readonly InventorySingleQueryHandler _cut;

        public InventorySingleQueryHandlerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InventoryMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();

            _cut = new InventorySingleQueryHandler(_inventoryQueryRepository.Object,
                _mapper);
        }

        [Fact]
        public async Task HandleMethod_WhenItemHasNotFound_ShouldReturnNotFoundException()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<InventorySingleQueryRequest>();

            _inventoryQueryRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Domain.Aggregate.Inventory>(null));

            //Act
            Func<Task> act = () => _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<NotFoundException>().WithMessage("Inventory not found");
        }
    }
}
