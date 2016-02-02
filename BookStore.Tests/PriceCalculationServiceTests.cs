using BookStore.Interfaces;
using BookStore.Implementation;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace BookStore.Tests
{

    [TestFixture]
    public class PriceCalculationServiceTests
    {
        private IPriceCalculationService _calculatorService;

        private IOrder _order;

        [SetUp]
        public void SetUp()
        {
            _calculatorService = new PriceCalculationService();
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_price_correctly_of_mixed_order_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo, Quantity = 2},
                    new Book{ BookChapter = BookEnum.ChapterThree, Quantity = 2},
                    new Book{ BookChapter = BookEnum.ChapterFour, Quantity = 2},
                    new Book{ BookChapter = BookEnum.ChapterFive, Quantity = 2},
                    new Book{ BookChapter = BookEnum.ChapterSix}
               }
            };
            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(65.6m);
        }

        [Test]
        public void CalculateOrderPrice_should_return_0_if_order_is_empty()
        {
            _order = new Order();

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(0m);
        }

        [Test]
        public void CalculateOrderPrice_should_return_0_if_order_is_null()
        {
            decimal actual = _calculatorService.CalculateOrderPrice(null);

            actual.Should().Be(0m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_no_discount_if_order_has_no_different_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne, Quantity = 2}
                }
            };

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(16m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_5_rate_discount_if_order_has_two_different_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo}
                }
            };

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(15.2m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_10_rate_discount_if_order_has_three_different_series()
        {
            _order = new Order
           {
               Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo},
                    new Book{ BookChapter = BookEnum.ChapterThree},
                }
           };

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(21.6m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_15_rate_discount_if_order_has_four_different_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo},
                    new Book{ BookChapter = BookEnum.ChapterThree},
                    new Book{ BookChapter = BookEnum.ChapterFour},
                }
            };
            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(27.2m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_25_rate_discount_if_order_has_five_different_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo},
                    new Book{ BookChapter = BookEnum.ChapterThree},
                    new Book{ BookChapter = BookEnum.ChapterFour},
                    new Book{ BookChapter = BookEnum.ChapterFive},
                }
            };

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(30m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_30_rate_discount_if_order_has_six_different_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo},
                    new Book{ BookChapter = BookEnum.ChapterThree},
                    new Book{ BookChapter = BookEnum.ChapterFour},
                    new Book{ BookChapter = BookEnum.ChapterFive},
                    new Book{ BookChapter = BookEnum.ChapterSix},
                }
            };

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(33.6m);
        }

        [Test]
        public void CalculateOrderPrice_should_calculate_35_rate_discount_if_order_has_seven_different_series()
        {
            _order = new Order
            {
                Books = new List<IBook>
                {
                    new Book{ BookChapter = BookEnum.ChapterOne},
                    new Book{ BookChapter = BookEnum.ChapterTwo},
                    new Book{ BookChapter = BookEnum.ChapterThree},
                    new Book{ BookChapter = BookEnum.ChapterFour},
                    new Book{ BookChapter = BookEnum.ChapterFive},
                    new Book{ BookChapter = BookEnum.ChapterSix},
                    new Book{ BookChapter = BookEnum.ChapterSeven}
                }
            };

            decimal actual = _calculatorService.CalculateOrderPrice(_order);

            actual.Should().Be(36.4m);
        }
    }
}
