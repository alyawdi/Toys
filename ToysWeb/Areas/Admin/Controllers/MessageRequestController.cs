using Microsoft.AspNetCore.Mvc;
using Toys.DataAccess.Data;
using Toys.Models;
using Toys.DataAccess.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageRequestController : Controller

    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            List<MessageRequest> objMessageRequestList = _unitOfWork.MessageRequest.GetAll().ToList();
            return View(objMessageRequestList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MessageRequest obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MessageRequest.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Perfect! Message request created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            MessageRequest messageRequestFromDb = _unitOfWork.MessageRequest.Get(u => u.Id == id);

            if (messageRequestFromDb == null)
            {
                return NotFound();
            }
            return View(messageRequestFromDb);
        }

        [HttpPost]
        public IActionResult Edit(MessageRequest obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MessageRequest.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Great! Message request updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            MessageRequest messageRequestFromDb = _unitOfWork.MessageRequest.Get(u => u.Id == id);

            if (messageRequestFromDb == null)
            {
                return NotFound();
            }
            return View(messageRequestFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            MessageRequest? obj = _unitOfWork.MessageRequest.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.MessageRequest.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Don't worry, Message request deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
