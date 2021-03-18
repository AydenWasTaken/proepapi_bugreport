using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// This controller exposes the interaction with the database regarding the <see cref="TestEFCore"/> objects.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class TestEFCoresController : ControllerBase
    {
        private readonly TestContext _context;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="context"></param>
        public TestEFCoresController(TestContext context)
        {
            _context = context;
        }

        // GET: TestEFCores
        /// <summary>
        /// This method gets all of the objects in the table.
        /// </summary>
        /// <returns>An IEnumerable of TestEFCore objects.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestEFCore>>> GetTestObjects()
        {
            return await _context.TestObjects.ToListAsync();
        }

        // GET: TestEFCores/5
        /// <summary>
        /// This method gets a specific TestEFCore object with a given id.
        /// </summary>
        /// <param name="id">The id of the TestEFCore to look for.</param>
        /// <returns>Returns the TestEFCore object with the given id. NotFound() otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TestEFCore>> GetTestEFCore(Guid id)
        {
            var testEFCore = await _context.TestObjects.FindAsync(id);

            if (testEFCore == null)
            {
                return NotFound();
            }

            return testEFCore;
        }

        // PUT: TestEFCores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// This method updates a TestEFCore with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testEFCore"></param>
        /// <returns>Returns NoContent(). If the id and testEFCore.Id are not equal, returns a BadRequest(). If the id is not found, returns NotFound()</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestEFCore(Guid id, TestEFCore testEFCore)
        {
            if (id != testEFCore.Id)
            {
                return BadRequest();
            }

            _context.Entry(testEFCore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestEFCoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: TestEFCores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// This method creates a new TestEFCore.
        /// </summary>
        /// <param name="testEFCore">The TestEFCore object to add.</param>
        /// <returns>Returns the created object.</returns>
        [HttpPost]
        public async Task<ActionResult<TestEFCore>> PostTestEFCore(TestEFCore testEFCore)
        {
            _context.TestObjects.Add(testEFCore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestEFCore", new { id = testEFCore.Id }, testEFCore);
        }

        // DELETE: TestEFCores/5
        /// <summary>
        /// Deletes a TestEFCore object with a given id.
        /// </summary>
        /// <param name="id">The id of the TestEFCore object to delete.</param>
        /// <returns>Returns the deleted object. Returns NotFound() when the id could not be found.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestEFCore>> DeleteTestEFCore(Guid id)
        {
            var testEFCore = await _context.TestObjects.FindAsync(id);
            if (testEFCore == null)
            {
                return NotFound();
            }

            _context.TestObjects.Remove(testEFCore);
            await _context.SaveChangesAsync();

            return testEFCore;
        }

        private bool TestEFCoreExists(Guid id)
        {
            return _context.TestObjects.Any(e => e.Id == id);
        }
    }
}
