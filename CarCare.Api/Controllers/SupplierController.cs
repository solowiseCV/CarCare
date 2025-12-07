using CarCare.DTOs.Supplier.RequestDto;
using CarCare.DTOs.Supplier.ResponseDto;
using CarCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSupplier(Guid id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            return Ok(supplier);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierRequestDto supplierDto)
        {
            var newSupplier = await _supplierService.CreateSupplierAsync(supplierDto);
            return CreatedAtAction(nameof(GetSupplier), new { id = newSupplier.Id }, newSupplier);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSupplier(Guid id, [FromBody] SupplierRequestDto supplierDto)
        {
            await _supplierService.UpdateSupplierAsync(id, supplierDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            await _supplierService.DeleteSupplierAsync(id);
            return NoContent();
        }
    }
}
