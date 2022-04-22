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

namespace GlobalPoC.Application.Inventory
{
    /// <summary>
    /// Unit test for NewInventoryCommandHandler class
    /// </summary>
    public class NewInventoryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IQueryRepository<Domain.Aggregate.Inventory>> _inventoryQueryRepository = new Mock<IQueryRepository<Domain.Aggregate.Inventory>>();
        private readonly Mock<IQueryRepository<Domain.Entities.Item>> _itemsQueryRepository = new Mock<IQueryRepository<Domain.Entities.Item>>();
        private readonly Mock<ICommandRepository<Domain.Aggregate.Inventory>> _inventoryCommandRepository = new Mock<ICommandRepository<Domain.Aggregate.Inventory>>();
        private readonly NewInventoryCommandHandler _cut;

        public NewInventoryCommandHandlerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InventoryMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();

            _cut = new NewInventoryCommandHandler(_inventoryCommandRepository.Object, 
                _inventoryQueryRepository.Object,
                _itemsQueryRepository.Object, 
                _mapper);
        }

        [Fact]
        public async Task HandleMethod_WhenItemHasNotFound_ShouldReturnNotFoundException()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<NewInventoryCommandRequest>();
            var itemsList = fixture.Create<IReadOnlyList<Domain.Entities.Item>>();

            _itemsQueryRepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult<IReadOnlyList<Domain.Entities.Item>>(itemsList.ToList()));

            //Act
            Func<Task> act = () => _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<NotFoundException>().WithMessage("Item to add not found");
        }
    }
}
