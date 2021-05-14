using CryptoCoin.SolutionCore.Domain.Interfaces;
using CryptoCoin.SolutionCore.Domain.Models.Filters;
using CryptoCoin.SolutionCore.Domain.Models.Integrations;
using CryptoCoin.SolutionCore.ViewModels;
using CryptoCoin.SolutionCore.ViewModels.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace CryptoCoin.SolutionCore.Controllers
{
    public class CryptoController : Controller
    {
        private readonly ICryptoAPIService _cryptoAPIService;

        public CryptoController(ICryptoAPIService _cryptoAPIService)
        {
            this._cryptoAPIService = _cryptoAPIService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        public JsonResult ListarEvolucaoMoeda(ChartCoinsFilter filter)
        {

            CryptoAPIResponseViewModelItens objToView = new CryptoAPIResponseViewModelItens();

            if (filter.CodTrade != 0 && filter.CodTo != 0)
            {
                List<CryptoAPIResponseModelItens> objTo = _cryptoAPIService.SearchCoinsTradeId((int)filter.CodTo);

                if (objTo.ToList().Count > 0)
                {
                    foreach (CryptoAPIResponseModelItens item in objTo)
                    {
                        objToView.symbol = item.symbol;
                        objToView.price_btc = item.price_btc;
                    }
                }
                else
                {
                    return Json(new { success = false, data = objTo });
                }



                List<CryptoAPIResponseViewModelForMarkets> objView = new List<CryptoAPIResponseViewModelForMarkets>();


                List<CryptoAPIResponseModelForMarkets> obj = _cryptoAPIService.SearchForMarket((int)filter.CodTrade);

                foreach (CryptoAPIResponseModelForMarkets item in obj.Where(q => q.quote == objToView.symbol).OrderBy(q => q.time))
                {
                    double tempoSegundo = Convert.ToDouble(item.time);
                    TimeSpan tempoPercorrido = TimeSpan.FromSeconds(tempoSegundo);
                    DateTime dateTime = DateTime.Today.Add(tempoPercorrido);


                    string displayTime = dateTime.ToString("HH:mm:ss");

                    CryptoAPIResponseViewModelForMarkets viewMarket = new CryptoAPIResponseViewModelForMarkets()
                    {
                        name = item.name,
                        quote = item.quote,
                        price = item.price,
                        price_usd = item.price_usd,

                        time = displayTime
                    };

                    objView.Add(viewMarket);
                }


                if (objView.Count > 0)
                    return Json(new { success = true, data = objView });

                return Json(new { success = false, data = objToView });
            }
            else
            {
                return Json(new { success = false, data = objToView });
            }

        }

        [HttpPost]
        public JsonResult JsonPartialTable(int? tradeId, int? toId)
        {

            if (tradeId != null && toId != null)
            {
                CryptoAPIResponseViewModelItens objToView = new CryptoAPIResponseViewModelItens();
                List<CryptoAPIResponseModelItens> objTo = _cryptoAPIService.SearchCoinsTradeId((int)toId);

                foreach (CryptoAPIResponseModelItens item in objTo)
                {
                    objToView.symbol = item.symbol;
                    objToView.price_btc = item.price_btc;
                }


                List<CryptoAPIResponseViewModelForMarkets> objView = new List<CryptoAPIResponseViewModelForMarkets>();


                List<CryptoAPIResponseModelForMarkets> obj = _cryptoAPIService.SearchForMarket((int)tradeId);

                foreach (CryptoAPIResponseModelForMarkets item in obj.Where(q => q.quote == objToView.symbol).OrderBy(q => q.price))
                {
                    CryptoAPIResponseViewModelForMarkets viewMarket = new CryptoAPIResponseViewModelForMarkets()
                    {
                        name = item.name,
                        quote = item.quote,
                        price = item.price,
                        price_usd = item.price_usd
                    };

                    objView.Add(viewMarket);
                }


                if (objView.Count > 0)
                    return Json(new { success = true, data = objView }, System.Web.Mvc.JsonRequestBehavior.AllowGet);

                return Json(new { success = false, data = objView }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, data = "" }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }

        }

        public PartialViewResult _PartialTable(int? tradeId, int? toId)
        {

            CryptoAPIResponseViewModelItens objToView = new CryptoAPIResponseViewModelItens();

            if (tradeId != null && toId != null)
            {
                List<CryptoAPIResponseModelItens> objTo = _cryptoAPIService.SearchCoinsTradeId((int)toId);

                foreach (CryptoAPIResponseModelItens item in objTo)
                {
                    objToView.symbol = item.symbol;
                    objToView.price_btc = item.price_btc;
                }


                List<CryptoAPIResponseViewModelForMarkets> objView = new List<CryptoAPIResponseViewModelForMarkets>();


                List<CryptoAPIResponseModelForMarkets> obj = _cryptoAPIService.SearchForMarket((int)tradeId);

                foreach (CryptoAPIResponseModelForMarkets item in obj.Where(q => q.quote == objToView.symbol).OrderBy(q => q.price))
                {
                    CryptoAPIResponseViewModelForMarkets viewMarket = new CryptoAPIResponseViewModelForMarkets()
                    {
                        name = item.name,
                        quote = item.quote,
                        price = item.price,
                        price_usd = item.price_usd
                    };

                    objView.Add(viewMarket);
                }


                return PartialView("_PartialTable", objView);
            }
            else
            {
                return PartialView("_PartialTable", objToView);
            }

        }

        public PartialViewResult _PartialConversionCoin(int? tradeId, int? toId)
        {
            if (tradeId != null && toId != null)
            {
                CryptoAPIResponseViewModelItens objTradeView = new CryptoAPIResponseViewModelItens();
                List<CryptoAPIResponseModelItens> objTrade = _cryptoAPIService.SearchCoinsTradeId((int)tradeId);

                foreach (CryptoAPIResponseModelItens item in objTrade)
                {
                    objTradeView.symbol = item.symbol;
                    objTradeView.price_btc = item.price_btc;
                }



                CryptoAPIResponseViewModelItens objToView = new CryptoAPIResponseViewModelItens();
                List<CryptoAPIResponseModelItens> objTo = _cryptoAPIService.SearchCoinsToId((int)toId);

                foreach (CryptoAPIResponseModelItens item2 in objTo)
                {
                    objToView.symbol = item2.symbol;
                    objToView.price_btc = item2.price_btc;
                    objToView.percent_change_1h = item2.percent_change_1h;
                }

                if (objTradeView.symbol == "BTC")
                {

                    ViewBag.TradeName = objTradeView.symbol;
                    ViewBag.Rate = objToView.price_btc;
                    ViewBag.ToName = objToView.symbol;
                    ViewBag.PercentChange1h = objToView.percent_change_1h;

                    ViewBag.QuoteName = objToView.symbol;
                    return PartialView();
                }
                else
                {
                    ViewBag.TradeName = "BTC ";
                    ViewBag.Rate = objToView.price_btc;
                    ViewBag.ToName = objToView.symbol;
                    ViewBag.PercentChange1h = objToView.percent_change_1h;

                    ViewBag.QuoteName = objToView.symbol;
                    return PartialView();
                }
            }
            else
            {
                ViewBag.TradeName = "BTC ";
                ViewBag.Rate = "";
                ViewBag.ToName = "";
                ViewBag.PercentChange1h = "";

                ViewBag.QuoteName = "";
                return PartialView();
            }

        }

        [HttpPost]
        public JsonResult ConversionCoin(int? trade, int? to)
        {

            return Json(new { success = false, message = "ok" });

        }

        private void LoadViewBags()
        {
            SelectListItem selectListItemSelecione = new SelectListItem();
            selectListItemSelecione.Text = "Select";
            selectListItemSelecione.Value = "";
            List<SelectListItem> selectlistItemCoin = new List<SelectListItem>();
            selectlistItemCoin.Add(selectListItemSelecione);
            foreach (CryptoAPIResponseModelItens item in _cryptoAPIService.SearchCoins())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.name;
                selectListItem.Value = "" + item.id;
                selectlistItemCoin.Add(selectListItem);
            }
            ViewBag.TradeCoin = new SelectList(selectlistItemCoin, "Value", "Text");
            ViewBag.ToCoin = new SelectList(selectlistItemCoin, "Value", "Text");
        }

    }
}
