using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using superheors.console.Services;
using superheors.console.Services.RateLimiting;
using superheros.console.Services.RateLimiting;

// ReSharper disable All

namespace superheros.console.tests.Services.RateLimiter_Tests;

public class When_checking_the_rate
{
    [Test]
    public async Task Given_the_rate_limiting_key_was_not_used_before_then_the_service_should_allow_the_request()
    {
        //arrange
        var config = new RateLimitConfig(TimeSpan.FromMinutes(1), 2);

        var sut = new RateLimiter(config);
        var key = "1";

        //act
        var result = await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);

        //assert
        Assert.AreEqual(result, true);
    }

    [Test]

    public async Task
        Given_the_key_was_used_3_times_in_the_past_minute_and_only_2_requests_are_allowed_per_minute_then_the_service_should_reject_the_third_request()
    {
        //arrange
        var config = new RateLimitConfig(TimeSpan.FromMinutes(1), 2);

        var sut = new RateLimiter(config);
        var key = "1";

        //act
        await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);
        await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);

        var result = await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);

        //assert
        Assert.AreEqual(result, false);
    }

    [Test]
    public async Task
        Given_the_key_was_used_3_times_in_the_past_minute_and_only_2_requests_are_allowed_per_minute_and_the_third_request_came_after_1_minute_then_the_service_should_accept_the_third_request()
    {
        //arrange
        var config = new RateLimitConfig(TimeSpan.FromSeconds(5), 2);

        var sut = new RateLimiter(config);
        var key = "1";

        //act
        await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);
        await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);

        await Task.Delay(5000);

        var result = await sut.IsRequestAllowedAsync(key, DateTime.Now.Ticks);

        //assert
        Assert.AreEqual(result, true);
    }

}