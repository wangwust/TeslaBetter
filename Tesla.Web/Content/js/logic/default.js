$(function () {
    //GetMonthlyChart();
    //GetLotteryChart();
    GetIndexStat();
    //GetLatestAppLog();
    //GetLatestAdminLog();
});

//数据统计
function GetMonthlyChart() {
    $.ajax({
        url: "/Default?handler=MonthlyDataStat",
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.state == "error") {
                $("#salarychart").parent().html("<h3>" + data.message + "</h3>");
            } else {
                var labelList = [], betList = [], winList = [];
                $.each(data, function (i, item) {
                    labelList.push(item.RecordDate);
                    betList.push(item.TotalBetMoney);
                    winList.push(item.TotalWinMoney);
                });

                var lineChartData = {
                    labels: labelList,
                    datasets: [
                        {
                            label: "My First dataset",
                            fillColor: "rgba(220,220,220,0.2)",
                            strokeColor: "rgba(220,220,220,1)",
                            pointColor: "rgba(220,220,220,1)",
                            pointStrokeColor: "#fff",
                            pointHighlightFill: "#fff",
                            pointHighlightStroke: "rgba(220,220,220,1)",
                            data: betList
                        },
                        {
                            label: "My Second dataset",
                            fillColor: "rgba(151,187,205,0.2)",
                            strokeColor: "rgba(151,187,205,1)",
                            pointColor: "rgba(151,187,205,1)",
                            pointStrokeColor: "#fff",
                            pointHighlightFill: "#fff",
                            pointHighlightStroke: "rgba(151,187,205,1)",
                            data: winList
                        }
                    ]
                }
                var ctx = document.getElementById("salarychart").getContext("2d");
                window.myLine = new Chart(ctx).Line(lineChartData, {
                    responsive: false,
                    bezierCurve: false
                });
            }
        }
    });
}

//获取彩种总的统计信息
function GetLotteryChart() {
    $.ajax({
        url: "/Default?handler=LotteryDataStat",
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.state == "error") {
                $("#div_lottery_icon").html("<h3>" + data.message + "</h3>");
            } else {
                var colorList = ["#F7464A", "#46BFBD", "#FDB45C", "#949FB1", "#E459FD", "#A34F9D"];
                var highlightList = ["#FF5A5E", "#5AD3D1", "#FFC870", "#A8B3C5", "#3AB45D", "#D34F3D"];
                var doughnutData = [];
                var lotteryIconHtml = "", lotteryInfoHtml = "";
                $.each(data, function (i, item) {
                    doughnutData.push({
                        value: item.TotalWinMoney,
                        color: colorList[i],
                        highlight: highlightList[i],
                        label: item.LotteryName
                    });

                    lotteryIconHtml += '<span><i class="fa fa-square" style="color: ' + colorList[i] + ';font-size: 20px; padding-right: 3px; vertical-align: middle; margin-top: -3px;margin-left: 8px;"></i>' + item.LotteryName + '</span>';
                    lotteryInfoHtml += '<div style="width: 16%; text-align: center; float: left;"><span id="a_value">' + item.TotalWinMoney + '</span><p style="color: #a1a1a1">' + item.LotteryName + '</p></div>';
                });

                var ctx = document.getElementById("leavechart").getContext("2d");
                window.myDoughnut = new Chart(ctx).Doughnut(doughnutData, { responsive: false });
                $("#div_lottery_icon").html(lotteryIconHtml);
                $("#div_lotttery_info").html(lotteryInfoHtml);
            }
        }
    });
}

//取关键数据实时指标
function GetIndexStat() {
    $.ajax({
        url: "/Home/GetBetAndWinMoney",
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.state == "error") {
                var message = "<h3>" + data.message + "</h3>";
                $("#today_bet_money").html(message);
                $("#today_win_money").html(message);
                $("#total_bet_money").html(message);
                $("#total_win_money").html(message);
            } else {
                $("#today_bet_money").html(data.TodayBetMoney + "￥");
                $("#today_win_money").html(data.TodayWinMoney + "￥");
                $("#total_bet_money").html(data.TotalBetMoney + "￥");
                $("#total_win_money").html(data.TotalWinMoney + "￥");
            }
        }
    });
}

//取最新的应用程序日志
function GetLatestAppLog() {
    $.ajax({
        url: "/Default?handler=AppLog",
        dataType: "json",
        async: true,
        success: function (data) {
            var html = "";
            if (data.state == "error") {
                html = "<h3>" + data.message + "</h3>";
            } else {
                $.each(data, function (i, item) {
                    var message = item.Message;
                    html += '<li><a onclick="ShowAppLog(' + item.ID + ')" href="#">' + message + '</a><span class="time">' + item.CreateTime + '</span></li>';
                });
            }

            $("#ul_applog").html(html);
        }
    });
}

function ShowAppLog(keyValue) {
    $.modalOpen({
        id: "Form",
        title: "日志详情",
        url: "/Game/Log/Details?keyValue=" + keyValue,
        width: "700px",
        height: "490px",
        btn: null
    });
}

//取最新的管理系统日志
function GetLatestAdminLog() {
    $.ajax({
        url: "/Default?handler=AdminLog",
        dataType: "json",
        async: true,
        success: function (data) {
            var html = "";
            if (data.state == "error") {
                html = "<h3>" + data.message + "</h3>";
            } else {
                $.each(data, function (i, item) {
                    var message = item.F_Description;
                    html += '<li><a onclick="ShowAdminLog(\'' + item.F_Id + '\')" href="#">' + message + '</a><span class="time">' + item.F_CreatorTime + '</span></li>';
                });
            }

            $("#ul_adminlog").html(html);
        }
    });
}

function ShowAdminLog(keyValue) {
    $.modalOpen({
        id: "Form",
        title: "日志详情",
        url: "/Admin/Log/Details?keyValue=" + keyValue,
        width: "700px",
        height: "490px",
        btn: null
    });
}