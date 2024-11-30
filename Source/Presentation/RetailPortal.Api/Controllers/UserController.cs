﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailPortal.Api.Controllers.Common;
using RetailPortal.Application.Commands;
using RetailPortal.Application.Commands.CreateUser;
using RetailPortal.Shared.DTOs;
using RetailPortal.Shared.DTOs.User;

namespace RetailPortal.Api.Controllers;

[ApiController]
[Route("api/v0.0/users")]
public class UserController(ISender sender, IMapper mapper): BaseController
{
    /// <summary>
    /// POST: api/v0.0/users
    /// TODO: Implement Automapper for mapping DTOs to Entities
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        var result = await sender.Send(mapper.Map<CreateUserCommand>(request));

        return result.Match(
            user => this.Ok(mapper.Map<CreateUserResponse>(user)),
            this.Problem
        );
    }
}