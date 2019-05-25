﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemasTheBESTia.Entities.CinemaFunctions;
using CinemasTheBESTia.Utilities.Abstractions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemasTheBESTia.CinemaBooking.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ICinemasService _cinemaFunctionsService;
        private readonly IBookingService _bookingService;

        public BookingController(ICinemasService cinemaFuctionsService, IBookingService bookingService)
        {
            _cinemaFunctionsService = cinemaFuctionsService;
            _bookingService = bookingService;
        }

        // GET api/originalTitle
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            return Ok(await _cinemaFunctionsService.GetFuctions(id));
        }



        [HttpGet("ReturnSeats/{functionId}")]
        public IActionResult ReturnSeats(int functionId)
        {
            return Ok(_cinemaFunctionsService.GetSeats(functionId));
        }

        // POST api/values
        [HttpPost]
        public IActionResult ProcessReserve(ReserveDTO reserveDTO)
        {
            if (reserveDTO == null)
            {
                return BadRequest();
            }
            return Ok(_bookingService.ProcessBooking(reserveDTO));

        }

        [HttpGet("CinemaFunction/{cinemafunctionId}")]
        public async Task<IActionResult> CinemaFunction(int cinemafunctionId)
        {
            if (cinemafunctionId < 0)
            {
                return BadRequest();
            }
            return Ok(await _cinemaFunctionsService.GetCinemaFunctionById(cinemafunctionId));
        }


    }
}
