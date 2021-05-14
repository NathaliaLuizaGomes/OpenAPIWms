$(document).ready(function () {

    //loadChart();
});

//var baseUrl = $("#BaseUrl").val();

var color = [
    '#26B99A', '#34495E', '#BDC3C7', '#3498DB',
    '#9B59B6', '#9a9556', '#759c6a', '#bfd3b7'
];

$("#RateCoinButton").click(function () {
    loadChart();
});


/* carregamento dos graficos */

var theme = {
    color: [
        '#26B99A', '#34495E', '#BDC3C7', '#3498DB',
        '#9B59B6', '#8abb6f', '#759c6a', '#bfd3b7'
    ],

    title: {
        itemGap: 8,
        textStyle: {
            fontWeight: 'normal',
            color: '#408829'
        }
    },

    dataRange: {
        color: ['#1f610a', '#97b58d']
    },

    toolbox: {
        color: ['#408829', '#408829', '#408829', '#408829']
    },

    tooltip: {
        backgroundColor: 'rgba(0,0,0,0.5)',
        axisPointer: {
            type: 'line',
            lineStyle: {
                color: '#408829',
                type: 'dashed'
            },
            crossStyle: {
                color: '#408829'
            },
            shadowStyle: {
                color: 'rgba(200,200,200,0.3)'
            }
        }
    },

    dataZoom: {
        dataBackgroundColor: '#eee',
        fillerColor: 'rgba(64,136,41,0.2)',
        handleColor: '#408829'
    },
    grid: {
        borderWidth: 0
    },

    categoryAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },

    valueAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitArea: {
            show: true,
            areaStyle: {
                color: ['rgba(250,250,250,0.1)', 'rgba(200,200,200,0.1)']
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },
    timeline: {
        lineStyle: {
            color: '#408829'
        },
        controlStyle: {
            normal: { color: '#408829' },
            emphasis: { color: '#408829' }
        }
    },

    k: {
        itemStyle: {
            normal: {
                color: '#68a54a',
                color0: '#a9cba2',
                lineStyle: {
                    width: 1,
                    color: '#408829',
                    color0: '#86b379'
                }
            }
        }
    },
    map: {
        itemStyle: {
            normal: {
                areaStyle: {
                    color: '#ddd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            },
            emphasis: {
                areaStyle: {
                    color: '#99d2dd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            }
        }
    },
    force: {
        itemStyle: {
            normal: {
                linkStyle: {
                    strokeColor: '#408829'
                }
            }
        }
    },
    chord: {
        padding: 4,
        itemStyle: {
            normal: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            },
            emphasis: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            }
        }
    },
    gauge: {
        startAngle: 225,
        endAngle: -45,
        axisLine: {
            show: true,
            lineStyle: {
                color: [[0.2, '#86b379'], [0.8, '#68a54a'], [1, '#408829']],
                width: 8
            }
        },
        axisTick: {
            splitNumber: 10,
            length: 12,
            lineStyle: {
                color: 'auto'
            }
        },
        axisLabel: {
            textStyle: {
                color: 'auto'
            }
        },
        splitLine: {
            length: 18,
            lineStyle: {
                color: 'auto'
            }
        },
        pointer: {
            length: '90%',
            color: 'auto'
        },
        title: {
            textStyle: {
                color: '#333'
            }
        },
        detail: {
            textStyle: {
                color: 'auto'
            }
        }
    },
    textStyle: {
        fontFamily: 'Arial, Verdana, sans-serif'
    }
};


function loadChart() {

    var element = $("#chartCoins");

    var filter = {
        CodTrade: $("#TradeCoin option:selected").val(),
        CodTo: $("#ToCoin option:selected").val()

    }

    $.ajax({
        url: 'Crypto/ListarEvolucaoMoeda',
        type: "POST",
        data: { filter: filter },
        success: function (response) {
            if (response.success) {
                carregaGraficoMoedas(response.data);
                //hideLoading(element);
            }

        },
        error: function (response) {
            //hideLoading(element);
            console.log('Erro ao carregar dados: ');
            console.log(response);
        }
    });

    function carregaGraficoMoedas(EvolucaoMoedas) {
        if ($('#evolucao_moedas').length) {

            var data = new Array();
            var legenda = new Array();
            var series = new Array();
            var categorias = new Array();
            var meses = new Array();
            var corretoras = new Array();


            categorias.push("Evolução");

            $.each(EvolucaoMoedas, function (i, d) {
                if (meses.indexOf(d.time) == -1)
                    meses.push(d.time);
            });

            $.each(EvolucaoMoedas, function (i, d) {
                if (corretoras.indexOf(d.name) == -1)
                    corretoras.push(d.name);
            });

            $.each(categorias, function (i, categoria) {
                var data = new Array();

                $.each(EvolucaoMoedas, function (index, evolucaoMoedas) {
                    data.push(evolucaoMoedas.price);
                });

                var serie = {
                    name: categoria,
                    type: 'line',
                    areaStyle: { normal: {} },
                    data: data,
                    itemStyle: {
                        normal: {
                            color: color[i],
                            label: {
                                show: true,
                                position: 'top',
                                textStyle: {
                                    color: '#000000'
                                }
                            }
                        }
                    }
                }

                series.push(serie);
            });


            var themeusutipo = {
                color: [
                    '#20bb9c', '#26b99a', '#A02626'
                ],
                grid: {
                    borderWidth: 0
                },

                valueAxis: {
                    splitArea: {
                        show: true,
                        areaStyle: {
                            color: ['rgba(250,250,250,0.1)', 'rgba(200,200,200,0.1)']
                        }
                    },
                    splitLine: {
                        lineStyle: {
                            color: ['#eee']
                        }
                    }
                }
            };

            var echartBar = echarts.init(document.getElementById('evolucao_moedas'), themeusutipo);

            echartBar.setOption({
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {
                        type: 'shadow'
                    }
                },
                legend: {
                    data: categorias,
                    textStyle: {
                        fontSize: 13,
                        fontStyle: 'normal',
                        fontWeight: 'normal',
                    },
                },
                toolbox: {
                    show: true,
                    feature: {
                        restore: {
                            show: true,
                            title: "Restaurar"
                        },
                        saveAsImage: {
                            show: true,
                            title: "Salvar Imagem"
                        }
                    }
                },
                calculable: true,
                xAxis: [{
                    type: 'category',
                    data: meses,
                    axisLabel: {
                        rotate: 0,
                        interval: 0,
                        textStyle: {
                            fontSize: 14
                        }
                    },
                    axisTick: {
                        show: false
                    }
                }],
                yAxis: [{
                    type: 'value',
                    axisTick: {
                        show: false
                    },
                    splitLine: {
                        show: false
                    }
                }],
                series: series
            });

            echartBar.on('click', function (params) {

            });

        }
    }
}