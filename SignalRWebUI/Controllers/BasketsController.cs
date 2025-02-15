﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.CouponCodeDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("https://localhost:7276/api/Basket/BasketListByMenuTableWithProductsName?id=20");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7276/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }


        public async Task<JsonResult> CouponCodeApprove(string title)
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync($"https://localhost:7276/api/Basket/20,{title}");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var couponResponse = JsonConvert.DeserializeObject<ResultBasketWithCoupon>(jsonData);

                return Json(couponResponse); 
            }
            return Json("0");
        }

    }
}
