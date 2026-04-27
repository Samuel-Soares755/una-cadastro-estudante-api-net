using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstudanteApi324147097.Data;
using CadastroEstudanteApi324147097.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace CadastroEstudanteApi324147097.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstudantesControllers : ControllerBase
{
    private readonly AppDbContext _context;

    public EstudantesControllers(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudantes()
    {
        return await _context.Estudantes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Estudante>> GetEstudante(int id)
    {
        var estudante = await _context.Estudantes.FindAsync(id);

        if (estudante == null) return NotFound();

        return estudante;
    }

    [HttpPost]
    public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
    {
        _context.Estudantes.Add(estudante);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEstudante), new {id = estudante.Id }, estudante);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEstudante(int id, Estudante estudante)
    {
        if (id != estudante.Id) return BadRequest();

        _context.Entry(estudante).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Estudantes.Any(e => e.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstudante(int id)
    {
        var estudante = await _context.Estudantes.FindAsync(id);
        if (estudante == null) return NotFound();

        _context.Estudantes.Remove(estudante);
        await _context.SaveChangesAsync();

        return NoContent();
    }










}