using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IDataRepository<Transaction> _dataRepository;
        public TransactionController(IDataRepository<Transaction> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Transaction
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Transaction> transactions = _dataRepository.GetAll();
            return Ok(transactions);
        }
        // GET: api/Transaction/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Transaction transaction = _dataRepository.Get(id);
            if (transaction == null)
            {
                return NotFound("The Transaction record couldn't be found.");
            }
            return Ok(transaction);
        }
        // POST: api/Transaction
        [HttpPost]
        public IActionResult Post([FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest("Transaction is null.");
            }
            _dataRepository.Add(transaction);
            return CreatedAtRoute(
                  "Get",
                  new { Id = transaction.TransactionId },
                  transaction);
        }
        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest("Transaction is null.");
            }
            Transaction transactionToUpdate = _dataRepository.Get(id);
            if (transactionToUpdate == null)
            {
                return NotFound("The Transaction record couldn't be found.");
            }
            _dataRepository.Update(transactionToUpdate, transaction);
            return NoContent();
        }
        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Transaction transaction = _dataRepository.Get(id);
            if (transaction == null)
            {
                return NotFound("The Transaction record couldn't be found.");
            }
            _dataRepository.Delete(transaction);
            return NoContent();
        }
    }
}
