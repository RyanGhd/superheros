using System;
using System.Threading.Tasks;
using NuGet.Frameworks;
using NUnit.Framework;
// ReSharper disable All

namespace superheros.console.tests;

[TestFixture]
public class Rate_limiter_tests
{
    [Test]
    public void Given_this_is_the_first_request_for_the_given_customer_When_checking_the_limit_then_the_service_should_accept_the_request()
    {
        //arrange
        var config = new RateLimitConfig(3, TimeSpan.FromSeconds(1));

        var sut = new RateLimiter(config);

        var customerId = 1;

        //act
        var result = sut.rateLimit(customerId);

        //assert
        Assert.AreEqual(result, true);
    }


    [Test]
    public async Task Given_we_recieved_2_requests_for_client_in_the_last_second_and_we_allow_2_requests_per_second_When_checking_the_limit_then_the_service_should_reject_the_request()
    {
        //arrange
        var config = new RateLimitConfig(2, TimeSpan.FromSeconds(5));
        var customerId = 1;
        var sut = new RateLimiter(config);

        //act
        var result1 = sut.rateLimit(customerId);
        var result2 = sut.rateLimit(customerId);
        var result3 = sut.rateLimit(customerId);

        await Task.Delay(5000);

        var result4 = sut.rateLimit(customerId);

        //assert
        Assert.AreEqual(result1, true);
        Assert.AreEqual(result2, true);
        Assert.AreEqual(result3, false);
        Assert.AreEqual(result4, true);
    }
}
// Perform rate limiting logic for provided customer ID. Return true if the
// request is allowed, and false if it is not.
// boolean rateLi2mit(int customerId)