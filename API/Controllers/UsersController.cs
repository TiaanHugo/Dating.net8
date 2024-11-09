using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return Ok(await _context.Users.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null) { return NotFound(); }

        return Ok(user);
    }
}
