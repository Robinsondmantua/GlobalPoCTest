using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Queries.Handlers;
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
    /// Unit test for NewInventoryCommandHandlerTest class
    /// </summary>
    public class DeleteItemInventoryCommandHandlerTest
    {
        private readonly Mock<IQueryRepository<Domain.Aggregate.Inventory>> _inventoryQueryRepository = new Mock<IQueryRepository<Domain.Aggregate.Inventory>>();
        private readonly Mock<ICommandRepository<Domain.Aggregate.Inventory>> _inventoryCommandRepository = new Mock<ICommandRepository<Domain.Aggregate.Inventory>>();
        private readonly DeleteItemInventoryCommandHandler _cut;

        public DeleteItemInventoryCommandHandlerTest()
        {
            _cut = new DeleteItemInventoryCommandHandler(_inventoryCommandRepository.Object, 
                _inventoryQueryRepository.Object);
        }

        [Fact]
        public async Task HandleMethod_WhenInventoryHasNotFound_ShouldReturnNotFoundException()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<DeleteItemInventoryCommandRequest>();

            _inventoryQueryRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Domain.Aggregate.Inventory>(null));

            //Act
            Func<Task> act = () => _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<NotFoundException>().WithMessage("Inventory not found");
        }

        [Fact]
        public async Task HandleMethod_WhenItemHasFoundByNameInTheInventory_ShouldReturnsOK()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<DeleteItemInventoryCommandRequest>();
            var inventory = fixture.Create<Domain.Aggregate.Inventory>();

            var item = fixture.Create<Domain.Entities.Item>();
            inventory.AddItem(item);
            queryRequest.ItemName = item.Name;
            
            _inventoryQueryRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(inventory));

            //Act
            var result = await _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            result.Should().Be(default);
        }
    }
}
