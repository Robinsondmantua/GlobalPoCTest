using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Queries.Handlers;
using Application.Features.Inventory.Queries.Request;
using Application.Features.Item.Queries.Handlers;
using Application.Features.Item.Queries.Request;
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

namespace GlobalPoC.Application.Item
{
    /// <summary>
    /// Unit test for ItemSingleQueryHandlerTest class
    /// </summary>
    public class ItemSingleQueryHandlerTest
    {
        private readonly Mock<IQueryRepository<Domain.Entities.Item>> _itemQueryRepository = new Mock<IQueryRepository<Domain.Entities.Item>>();
        private readonly IMapper _mapper;
        private readonly ItemSingleQueryHandler _cut;

        public ItemSingleQueryHandlerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ItemMapProfile());
            });

            _mapper = mockMapper.CreateMapper();

            _cut = new ItemSingleQueryHandler(_itemQueryRepository.Object,
                _mapper);
        }

        [Fact]
        public async Task HandleMethod_WhenItemHasNotFound_ShouldReturnNotFoundException()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var queryRequest = fixture.Create<ItemSingleQueryRequest>();

            _itemQueryRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult<Domain.Entities.Item>(null));

            //Act
            Func<Task> act = () => _cut.Handle(queryRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<NotFoundException>().WithMessage("Item not found");
        }
    }
}
