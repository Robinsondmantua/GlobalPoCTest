using Application.Mapping;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace GlobalPoC.Application.Item
{
	/// <summary>
	/// Unit test for Item mapping class
	/// </summary>
	public class ItemToItemDto
	{
        private readonly IMapper _mapper;

		public ItemToItemDto()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ItemMapProfile());
			});

			_mapper = mockMapper.CreateMapper();
		}

		[Fact]
		public void ItemEntity_To_ItemDto()
		{
			//Arrange
			var fixture = new Fixture();
			fixture.Customize(new AutoMoqCustomization());
			var entity = fixture.Create<Domain.Entities.Item>();

			//Act
			var dto = _mapper.Map<Domain.Entities.Item>(entity);

			//Assert
			dto.ExpirationDate.Should().Be(entity.ExpirationDate);
			dto.Name.Should().Be(entity.Name);
			dto.Type.Should().Be(entity.Type);

		}
	}
}
