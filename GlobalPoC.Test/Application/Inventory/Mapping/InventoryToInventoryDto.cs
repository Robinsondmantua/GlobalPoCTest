using System;
using System.Collections.Generic;
using System.Text;
using Application.Features.Inventory.Dtos;
using Application.Mapping;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace GlobalPoC.Application.Inventory
{
	/// <summary>
	/// Unit test for Inventory mapping class
	/// </summary>

	public class InventoryToInventoryDto
	{
        private readonly IMapper _mapper;

		public InventoryToInventoryDto()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new InventoryMappingProfile());
			});

			_mapper = mockMapper.CreateMapper();
		}

		[Fact]
		public void InventoryAggregate_To_InventryDto()
		{
			//Arrange
			var fixture = new Fixture();
			fixture.Customize(new AutoMoqCustomization());
			var aggregate = fixture.Create<Domain.Aggregate.Inventory>();

			//Act
			var dto = _mapper.Map<InventoryDto>(aggregate);

			//Assert
			dto.Description.Should().Be(aggregate.Description);
			dto.Name.Should().Be(aggregate.Name);
			dto.Items.Should().HaveCount(aggregate.Items.Count);

		}
	}
}
