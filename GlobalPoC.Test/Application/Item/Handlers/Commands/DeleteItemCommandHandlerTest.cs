using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Item.Commands.Request;
using Application.Features.Item.Queries.Handlers;
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
    /// Unit test for DeleteItemCommandHandler class
    /// </summary>
    public class DeleteItemCommandHandlerTest
    {
        private readonly Mock<ICommandRepository<Domain.Entities.Item>> _itemCommandRepository = new Mock<ICommandRepository<Domain.Entities.Item>>();
        private readonly Mock<IQueryRepository<Domain.Entities.Item>> _itemQueryRepository =  new Mock<IQueryRepository<Domain.Entities.Item>>();
        private readonly DeleteItemCommandHandler _cut;

        public DeleteItemCommandHandlerTest()
        {
            _cut = new DeleteItemCommandHandler(_itemCommandRepository.Object,
                _itemQueryRepository.Object);
        }

        [Fact]
        public async Task HandleMethod_WhenInventoryHasNotFound_ShouldReturnNotFoundException()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<DeleteItemCommandRequest>();

            _itemQueryRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Domain.Entities.Item>(null));

            //Act
            Func<Task> act = () => _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<NotFoundException>().WithMessage("Item not found");
        }
    }
}
