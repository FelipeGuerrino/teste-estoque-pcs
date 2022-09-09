using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;

namespace src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        private readonly IRepository _repo;

        public ComputerController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id = 0)
        {
            if(id == 0)
            {
                var result = await _repo.GetAllComputersAsync();
                return Ok(result);
            }
            else
            {
                var result = await _repo.GetComputersAsyncById(id);
                return Ok(result);
            }
        }
        [HttpGet("search/{text}")]
        public async Task<IActionResult> Get(string text)
        {
            var result = await _repo.GetComputersAsyncBySearch(text);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Computer pc)
        {
            _repo.Add(pc);

            if(await _repo.SaveChangesAsync())
            {
                return Ok(pc);
            }
            else
            {
                return BadRequest("Erro ao criar objeto no banco de dados");
            }
            
        }

        [HttpPut("{computerId}")]
        public async Task<IActionResult> Put(int computerId, Computer pc)
        {
            var computer = await _repo.GetComputersAsyncById(computerId);
            if(computer == null) return NotFound();
            
            _repo.Update(pc);

            if(await _repo.SaveChangesAsync())
            {
                return Ok(pc);
            }
            else
            {
                return BadRequest("Erro ao atualizar objeto no banco de dados");
            }
            
        }
        [HttpDelete("{computerId}")]
        public async Task<IActionResult> Delete(int computerId)
        {
            var computer = await _repo.GetComputersAsyncById(computerId);
            if(computer == null) return NotFound();
            
            _repo.Delete(computer[0]);

            if(await _repo.SaveChangesAsync())
            {
                return Ok("Deletado");
            }
            else
            {
                return BadRequest("Erro ao remover objeto no banco de dados");
            }
            
        }
    }
}