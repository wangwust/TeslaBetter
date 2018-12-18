﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Model
{
    /// <summary>
    /// GamePlayEnum
    /// </summary>
    public static class GamePlayEnum
    {
        /// <summary>
        /// BJKC
        /// </summary>
        public static Dictionary<string, string> BJKCDic => new Dictionary<string, string>
        {
                //{"501005",  "冠、亚军和 3 "  }  ,
                //{"501006",  "冠、亚军和 4 "  }  ,
                //{"501007",  "冠、亚军和 5 "  }  ,
                //{"501008",  "冠、亚军和 6 "  }  ,
                //{"501009",  "冠、亚军和 7 "  }  ,
                //{"501010",  "冠、亚军和 8 "  }  ,
                //{"501011",  "冠、亚军和 9 "  }  ,
                //{"501012",  "冠、亚军和 10"  }  ,
                //{"501013",  "冠、亚军和 11"  }  ,
                //{"501014",  "冠、亚军和 12"  }  ,
                //{"501015",  "冠、亚军和 13"  }  ,
                //{"501016",  "冠、亚军和 14"  }  ,
                //{"501017",  "冠、亚军和 15"  }  ,
                //{"501018",  "冠、亚军和 16"  }  ,
                //{"501019",  "冠、亚军和 17"  }  ,
                //{"501020",  "冠、亚军和 18"  }  ,
                //{"501021",  "冠、亚军和 19"  }  ,
                {"501101",  "冠军 大 "     }  ,
                {"501102",  "冠军 小 "     }  ,
                {"501103",  "冠军 单 "     }  ,
                {"501104",  "冠军 双 "     }  ,
                {"501105",  "冠军 龙 "     }  ,
                {"501106",  "冠军 虎 "     }  ,
                {"501201",  "亚军 大 "     }  ,
                {"501202",  "亚军 小 "     }  ,
                {"501203",  "亚军 单 "     }  ,
                {"501204",  "亚军 双 "     }  ,
                {"501205",  "亚军 龙 "     }  ,
                {"501206",  "亚军 虎 "     }  ,
                //{"501107",  "冠军 1  "     }  ,
                //{"501108",  "冠军 2  "     }  ,
                //{"501109",  "冠军 3  "     }  ,
                //{"501110",  "冠军 4  "     }  ,
                //{"501111",  "冠军 5  "     }  ,
                //{"501112",  "冠军 6  "     }  ,
                //{"501113",  "冠军 7  "     }  ,
                //{"501114",  "冠军 8  "     }  ,
                //{"501115",  "冠军 9  "     }  ,
                //{"501116",  "冠军 10 "     }  ,

                //{"501207",  "亚军 1  "     }  ,
                //{"501208",  "亚军 2  "     }  ,
                //{"501209",  "亚军 3  "     }  ,
                //{"501210",  "亚军 4  "     }  ,
                //{"501211",  "亚军 5  "     }  ,
                //{"501212",  "亚军 6  "     }  ,
                //{"501213",  "亚军 7  "     }  ,
                //{"501214",  "亚军 8  "     }  ,
                //{"501215",  "亚军 9  "     }  ,
                //{"501216",  "亚军 10 "     }  ,
                {"501301",  "第三名 大"     }  ,
                {"501302",  "第三名 小"     }  ,
                {"501303",  "第三名 单"     }  ,
                {"501304",  "第三名 双"     }  ,
                {"501305",  "第三名 龙"     }  ,
                {"501306",  "第三名 虎"     }  ,
                //{"501307",  "第三名 1"     }  ,
                //{"501308",  "第三名 2"     }  ,
                //{"501309",  "第三名 3"     }  ,
                //{"501310",  "第三名 4"     }  ,
                //{"501311",  "第三名 5"     }  ,
                //{"501312",  "第三名 6"     }  ,
                //{"501313",  "第三名 7"     }  ,
                //{"501314",  "第三名 8"     }  ,
                //{"501315",  "第三名 9"     }  ,
                //{"501316",  "第三名 10"     }  ,
                {"501401",  "第四名 大"     }  ,
                {"501402",  "第四名 小"     }  ,
                {"501403",  "第四名 单"     }  ,
                {"501404",  "第四名 双"     }  ,
                {"501405",  "第四名 龙"     }  ,
                {"501406",  "第四名 虎"     }  ,
                //{"501407",  "第四名 1"     }  ,
                //{"501408",  "第四名 2"     }  ,
                //{"501409",  "第四名 3"     }  ,
                //{"501410",  "第四名 4"     }  ,
                //{"501411",  "第四名 5"     }  ,
                //{"501412",  "第四名 6"     }  ,
                //{"501413",  "第四名 7"     }  ,
                //{"501414",  "第四名 8"     }  ,
                //{"501415",  "第四名 9"     }  ,
                //{"501416",  "第四名 10"     }  ,
                {"501501",  "第五名 大"     }  ,
                {"501502",  "第五名 小"     }  ,
                {"501503",  "第五名 单"     }  ,
                {"501504",  "第五名 双"     }  ,
                {"501505",  "第五名 龙"     }  ,
                {"501506",  "第五名 虎"     }  ,
                //{"501507",  "第五名 1"     }  ,
                //{"501508",  "第五名 2"     }  ,
                //{"501509",  "第五名 3"     }  ,
                //{"501510",  "第五名 4"     }  ,
                //{"501511",  "第五名 5"     }  ,
                //{"501512",  "第五名 6"     }  ,
                //{"501513",  "第五名 7"     }  ,
                //{"501514",  "第五名 8"     }  ,
                //{"501515",  "第五名 9"     }  ,
                //{"501516",  "第五名 10"     }  ,
                {"501601",  "第六名 大"     }  ,
                {"501602",  "第六名 小"     }  ,
                {"501603",  "第六名 单"     }  ,
                {"501604",  "第六名 双"     }  ,
                //{"501607",  "第六名 1"     }  ,
                //{"501608",  "第六名 2"     }  ,
                //{"501609",  "第六名 3"     }  ,
                //{"501610",  "第六名 4"     }  ,
                //{"501611",  "第六名 5"     }  ,
                //{"501612",  "第六名 6"     }  ,
                //{"501613",  "第六名 7"     }  ,
                //{"501614",  "第六名 8"     }  ,
                //{"501615",  "第六名 9"     }  ,
                //{"501616",  "第六名 10"     }  ,
                {"501701",  "第七名 大"     }  ,
                {"501702",  "第七名 小"     }  ,
                {"501703",  "第七名 单"     }  ,
                {"501704",  "第七名 双"     }  ,
                {"501801",  "第八名 大"     }  ,
                {"501802",  "第八名 小"     }  ,
                {"501803",  "第八名 单"     }  ,
                {"501804",  "第八名 双"     }  ,
                {"501901",  "第九名 大"     }  ,
                {"501902",  "第九名 小"     }  ,
                {"501903",  "第九名 单"     }  ,
                {"501904",  "第九名 双"     }  ,
                {"502001",  "第十名 大"     }  ,
                {"502002",  "第十名 小"     }  ,
                {"502003",  "第十名 单"     }  ,
                {"502004",  "第十名 双"     }  ,
                //{"501707",  "第七名 1"     }  ,
                //{"501708",  "第七名 2"     }  ,
                //{"501709",  "第七名 3"     }  ,
                //{"501710",  "第七名 4"     }  ,
                //{"501711",  "第七名 5"     }  ,
                //{"501712",  "第七名 6"     }  ,
                //{"501713",  "第七名 7"     }  ,
                //{"501714",  "第七名 8"     }  ,
                //{"501715",  "第七名 9"     }  ,
                //{"501716",  "第七名 10"     }  ,
                //{"501807",  "第八名 1"     }  ,
                //{"501808",  "第八名 2"     }  ,
                //{"501809",  "第八名 3"     }  ,
                //{"501810",  "第八名 4"     }  ,
                //{"501811",  "第八名 5"     }  ,
                //{"501812",  "第八名 6"     }  ,
                //{"501813",  "第八名 7"     }  ,
                //{"501814",  "第八名 8"     }  ,
                //{"501815",  "第八名 9"     }  ,
                //{"501816",  "第八名 10"     }  ,
                //{"501907",  "第九名 1"     }  ,
                //{"501908",  "第九名 2"     }  ,
                //{"501909",  "第九名 3"     }  ,
                //{"501910",  "第九名 4"     }  ,
                //{"501911",  "第九名 5"     }  ,
                //{"501912",  "第九名 6"     }  ,
                //{"501913",  "第九名 7"     }  ,
                //{"501914",  "第九名 8"     }  ,
                //{"501915",  "第九名 9"     }  ,
                //{"501916",  "第九名 10"     }  ,
                //{"502007",  "第十名 1"     }  ,
                //{"502008",  "第十名 2"     }  ,
                //{"502009",  "第十名 3"     }  ,
                //{"502010",  "第十名 4"     }  ,
                //{"502011",  "第十名 5"     }  ,
                //{"502012",  "第十名 6"     }  ,
                //{"502013",  "第十名 7"     }  ,
                //{"502014",  "第十名 8"     }  ,
                //{"502015",  "第十名 9"     }  ,
                //{"502016",  "第十名 10 "   }  ,
                //{"501001",  "冠亚大"          } ,
                //{"501002",  "冠亚小"          } ,
                //{"501003",  "冠亚单"          } ,
                //{"501004",  "冠亚双"          } 
            //{"503001",  "冠亚军组合 1-2 " }  ,
            //{"503002",  "冠亚军组合 1-3 " }  ,
            //{"503003",  "冠亚军组合 1-4 " }  ,
            //{"503004",  "冠亚军组合 1-5 " }  ,
            //{"503005",  "冠亚军组合 1-6 " }  ,
            //{"503006",  "冠亚军组合 1-7 " }  ,
            //{"503007",  "冠亚军组合 1-8 " }  ,
            //{"503008",  "冠亚军组合 1-9 " }  ,
            //{"503009",  "冠亚军组合 1-10" }  ,
            //{"503010",  "冠亚军组合 2-3 " }  ,
            //{"503011",  "冠亚军组合 2-4 " }  ,
            //{"503012",  "冠亚军组合 2-5 " }  ,
            //{"503013",  "冠亚军组合 2-6 " }  ,
            //{"503014",  "冠亚军组合 2-7 " }  ,
            //{"503015",  "冠亚军组合 2-8 " }  ,
            //{"503016",  "冠亚军组合 2-9 " }  ,
            //{"503017",  "冠亚军组合 2-10" }  ,
            //{"503018",  "冠亚军组合 3-4 " }  ,
            //{"503019",  "冠亚军组合 3-5 " }  ,
            //{"503020",  "冠亚军组合 3-6 " }  ,
            //{"503021",  "冠亚军组合 3-7 " }  ,
            //{"503022",  "冠亚军组合 3-8 " }  ,
            //{"503023",  "冠亚军组合 3-9 " }  ,
            //{"503024",  "冠亚军组合 3-10" }  ,
            //{"503025",  "冠亚军组合 4-5 "}  ,
            //{"503026",  "冠亚军组合 4-6 "}  ,
            //{"503027",  "冠亚军组合 4-7 "}  ,
            //{"503028",  "冠亚军组合 4-8 "}  ,
            //{"503029",  "冠亚军组合 4-9 "}  ,
            //{"503030",  "冠亚军组合 4-10"}  ,
            //{"503031",  "冠亚军组合 5-6 "}  ,
            //{"503032",  "冠亚军组合 5-7 "}  ,
            //{"503033",  "冠亚军组合 5-8 "}  ,
            //{"503034",  "冠亚军组合 5-9 "}  ,
            //{"503035",  "冠亚军组合 5-10"}  ,
            //{"503036",  "冠亚军组合 6-7 "}  ,
            //{"503037",  "冠亚军组合 6-8 "}  ,
            //{"503038",  "冠亚军组合 6-9 "}  ,
            //{"503039",  "冠亚军组合 6-10"}  ,
            //{"503040",  "冠亚军组合 7-8 "}  ,
            //{"503041",  "冠亚军组合 7-9 "}  ,
            //{"503042",  "冠亚军组合 7-10"}  ,
            //{"503043",  "冠亚军组合 8-9 "}  ,
            //{"503044",  "冠亚军组合 8-10"}  ,
            //{"503045",  "冠亚军组合 9-10"} 
        };

        /// <summary>
        /// XYFTDic
        /// </summary>
        public static Dictionary<string, string> XYFTDic => new Dictionary<string, string>
        {
                //{"5510201",  "冠军 1  "   }  ,
                //{"5510202",  "冠军 2  "   }  ,
                //{"5510203",  "冠军 3  "   }  ,
                //{"5510204",  "冠军 4  "   }  ,
                //{"5510205",  "冠军 5  "   }  ,
                //{"5510206",  "冠军 6  "   }  ,
                //{"5510207",  "冠军 7  "   }  ,
                //{"5510208",  "冠军 8  "   }  ,
                //{"5510209",  "冠军 9  "   }  ,
                //{"5510210",  "冠军 10 "    }  ,
                {"5510211",  "冠军 大 "    }  ,
                {"5510212",  "冠军 小 "    }  ,
                {"5510213",  "冠军 单 "    }  ,
                {"5510214",  "冠军 双 "    }  ,
                {"5510215",  "冠军 龙 "    }  ,
                {"5510216",  "冠军 虎 "    }  ,
                //{"5510301",  "亚军 1  "   }  ,
                //{"5510302",  "亚军 2  "   }  ,
                //{"5510303",  "亚军 3  "   }  ,
                //{"5510304",  "亚军 4  "   }  ,
                //{"5510305",  "亚军 5  "   }  ,
                //{"5510306",  "亚军 6  "   }  ,
                //{"5510307",  "亚军 7  "   }  ,
                //{"5510308",  "亚军 8  "   }  ,
                //{"5510309",  "亚军 9  "   }  ,
                //{"5510310",  "亚军 10 "    }  ,
                {"5510311",  "亚军 大 "    }  ,
                {"5510312",  "亚军 小 "    }  ,
                {"5510313",  "亚军 单 "    }  ,
                {"5510314",  "亚军 双 "    }  ,
                {"5510315",  "亚军 龙 "    }  ,
                {"5510316",  "亚军 虎 "    }  ,
                //{"5510401",  "第三名 1"     }  ,
                //{"5510402",  "第三名 2"     }  ,
                //{"5510403",  "第三名 3"     }  ,
                //{"5510404",  "第三名 4"     }  ,
                //{"5510405",  "第三名 5"     }  ,
                //{"5510406",  "第三名 6"     }  ,
                //{"5510407",  "第三名 7  "  }  ,
                //{"5510408",  "第三名 8  "  }  ,
                //{"5510409",  "第三名 9  "  }  ,
                //{"5510410",  "第三名 10 "   }  ,
                {"5510411",  "第三名 大 "   }  ,
                {"5510412",  "第三名 小 "   }  ,
                {"5510413",  "第三名 单 "   }  ,
                {"5510414",  "第三名 双 "   }  ,
                {"5510415",  "第三名 龙 "   }  ,
                {"5510416",  "第三名 虎"     }  ,
                //{"5510501",  "第四名 1"     }  ,
                //{"5510502",  "第四名 2"     }  ,
                //{"5510503",  "第四名 3"     }  ,
                //{"5510504",  "第四名 4"     }  ,
                //{"5510505",  "第四名 5"     }  ,
                //{"5510506",  "第四名 6"     }  ,
                //{"5510507",  "第四名 7  "  }  ,
                //{"5510508",  "第四名 8  "  }  ,
                //{"5510509",  "第四名 9  "  }  ,
                //{"5510510",  "第四名 10 "   }  ,
                {"5510511",  "第四名 大 "   }  ,
                {"5510512",  "第四名 小 "   }  ,
                {"5510513",  "第四名 单 "   }  ,
                {"5510514",  "第四名 双 "   }  ,
                {"5510515",  "第四名 龙 "   }  ,
                {"5510516",  "第四名 虎"     }  ,
                //{"5510601",  "第五名 1 "  }  ,
                //{"5510602",  "第五名 2 "  }  ,
                //{"5510603",  "第五名 3 "  }  ,
                //{"5510604",  "第五名 4 "  }  ,
                //{"5510605",  "第五名 5 "  }  ,
                //{"5510606",  "第五名 6 "  }  ,
                //{"5510607",  "第五名 7 " }  ,
                //{"5510608",  "第五名 8 " }  ,
                //{"5510609",  "第五名 9 " }  ,
                //{"5510610",  "第五名 10"  }  ,
                {"5510611",  "第五名 大"  }  ,
                {"5510612",  "第五名 小"  }  ,
                {"5510613",  "第五名 单"  }  ,
                {"5510614",  "第五名 双"  }  ,
                {"5510615",  "第五名 龙"  }  ,
                {"5510616",  "第五名 虎"   }  ,
                //{"5510701",  "第六名 1 "  }  ,
                //{"5510702",  "第六名 2 "  }  ,
                //{"5510703",  "第六名 3 "  }  ,
                //{"5510704",  "第六名 4 "  }  ,
                //{"5510705",  "第六名 5 " }  ,
                //{"5510706",  "第六名 6 " }  ,
                //{"5510707",  "第六名 7 " }  ,
                //{"5510708",  "第六名 8 " }  ,
                //{"5510709",  "第六名 9 " }  ,
                //{"5510710",  "第六名 10" }  ,
                {"5510711",  "第六名 大" }  ,
                {"5510712",  "第六名 小" }  ,
                {"5510713",  "第六名 单" }  ,
                {"5510714",  "第六名 双"  }  ,
                //{"5510801",  "第七名 1 " }  ,
                //{"5510802",  "第七名 2 " }  ,
                //{"5510803",  "第七名 3 " }  ,
                //{"5510804",  "第七名 4 " }  ,
                //{"5510805",  "第七名 5 "}  ,
                //{"5510806",  "第七名 6 "}  ,
                //{"5510807",  "第七名 7 "}  ,
                //{"5510808",  "第七名 8 "}  ,
                //{"5510809",  "第七名 9 "}  ,
                //{"5510810",  "第七名 10" }  ,
                {"5510811",  "第七名 大" }  ,
                {"5510812",  "第七名 小" }  ,
                {"5510813",  "第七名 单" }  ,
                {"5510814",  "第七名 双"  }  ,
                //{"5510901",  "第八名 1 " }  ,
                //{"5510902",  "第八名 2 " }  ,
                //{"5510903",  "第八名 3 " }  ,
                //{"5510904",  "第八名 4 " }  ,
                //{"5510905",  "第八名 5 " }  ,
                //{"5510906",  "第八名 6 " }  ,
                //{"5510907",  "第八名 7 " }  ,
                //{"5510908",  "第八名 8 " }  ,
                //{"5510909",  "第八名 9 " }  ,
                //{"5510910",  "第八名 10"  }  ,
                {"5510911",  "第八名 大"  }  ,
                {"5510912",  "第八名 小"  }  ,
                {"5510913",  "第八名 单"  }  ,
                {"5510914",  "第八名 双"   }  ,
                //{"5511001",  "第九名 1 "  }  ,
                //{"5511002",  "第九名 2 "  }  ,
                //{"5511003",  "第九名 3 "  }  ,
                //{"5511004",  "第九名 4 "  }  ,
                //{"5511005",  "第九名 5 " }  ,
                //{"5511006",  "第九名 6 " }  ,
                //{"5511007",  "第九名 7 " }  ,
                //{"5511008",  "第九名 8 " }  ,
                //{"5511009",  "第九名 9 " }  ,
                //{"5511010",  "第九名 10"  }  ,
                {"5511011",  "第九名 大"  }  ,
                {"5511012",  "第九名 小"  }  ,
                {"5511013",  "第九名 单"  }  ,
                {"5511014",  "第九名 双"   }  ,
                //{"5511101",  "第十名 1 "  }  ,
                //{"5511102",  "第十名 2 "  }  ,
                //{"5511103",  "第十名 3 "  }  ,
                //{"5511104",  "第十名 4 "  }  ,
                //{"5511105",  "第十名 5 " }  ,
                //{"5511106",  "第十名 6 " }  ,
                //{"5511107",  "第十名 7 " }  ,
                //{"5511108",  "第十名 8 " }  ,
                //{"5511109",  "第十名 9 " }  ,
                //{"5511110",  "第十名 10 " }  ,
                {"5511111",  "第十名 大 " }  ,
                {"5511112",  "第十名 小 " }  ,
                {"5511113",  "第十名 单 " }  ,
                {"5511114",  "第十名 双 "    },
                //{"5510101",  "冠亚大 "   } ,
                //{"5510102",  "冠亚小 "   } ,
                //{"5510103",  "冠亚单 "   } ,
                //{"5510104",  "冠亚双 "   } ,
                //{"5510105",  "冠、亚军和 3"  }  ,
                //{"5510106",  "冠、亚军和 4"  }  ,
                //{"5510107",  "冠、亚军和 5"  }  ,
                //{"5510108",  "冠、亚军和 6"  }  ,
                //{"5510109",  "冠、亚军和 7"  }  ,
                //{"5510110",  "冠、亚军和 8"  }  ,
                //{"5510111",  "冠、亚军和 9"  }  ,
                //{"5510112",  "冠、亚军和 10"  }  ,
                //{"5510113",  "冠、亚军和 11"  }  ,
                //{"5510114",  "冠、亚军和 12"  }  ,
                //{"5510115",  "冠、亚军和 13"  }  ,
                //{"5510116",  "冠、亚军和 14"  }  ,
                //{"5510117",  "冠、亚军和 15"  }  ,
                //{"5510118",  "冠、亚军和 16"  }  ,
                //{"5510119",  "冠、亚军和 17"  }  ,
                //{"5510120",  "冠、亚军和 18"  }  ,
                //{"5510121",  "冠、亚军和 19"  }
        };
    }
}