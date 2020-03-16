using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations.Include(r => r.Client).Include(r => r.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public async Task<IActionResult> Create()
        {
            var rooms = await _context.Rooms.Where(x => x.IsOccupied == false).ToListAsync();
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["RoomId"] = new SelectList(rooms, "Id", "Id");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomId,ClientId,DateOfEntry,DateOfExpiry,Breakfast,AllIncusive,Bill")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                Room room = await _context.Rooms.FindAsync(reservation.RoomId);
                Client client = await _context.Clients.FindAsync(reservation.ClientId);
                room.IsOccupied = true;
                _context.Update(room);

                reservation.Id = Guid.NewGuid().ToString();
                if (client.Age >= 18)
                {
                    if (reservation.Breakfast == true)
                    {
                        if (reservation.AllIncusive == true)
                        {
                            reservation.Bill = (35 + room.PriceForAdult) * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                        }
                        else
                        {
                            reservation.Bill = (5 + room.PriceForAdult) * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                        }
                    }
                    else if (reservation.AllIncusive == true)
                    {
                        reservation.Bill = (30 + room.PriceForAdult) * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                    }
                    else
                    {
                        reservation.Bill = room.PriceForAdult * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                    }
                }
                else
                {
                    if (reservation.Breakfast == true)
                    {
                        if (reservation.AllIncusive == true)
                        {
                            reservation.Bill = (35 + room.PriceForChild) * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                        }
                        else
                        {
                            reservation.Bill = (5 + room.PriceForChild) * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                        }
                    }
                    else if (reservation.AllIncusive == true)
                    {
                        reservation.Bill = (30 + room.PriceForChild) * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                    }
                    else
                    {
                        reservation.Bill = room.PriceForChild * (decimal)(reservation.DateOfExpiry - reservation.DateOfEntry).TotalDays;
                    }
                }
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reservation.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reservation.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RoomId,ClientId,DateOfEntry,DateOfExpiry,Breakfast,AllIncusive,Bill")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reservation.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(string id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
