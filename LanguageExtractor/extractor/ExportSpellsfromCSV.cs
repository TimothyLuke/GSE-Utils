﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace extractor
{
    class ExportSPelklsfromCSV
    {
        static string apikey = "apikey=ryksyb6993en4ptamrzan6yyvv28gzgt";


        static void Main(string[] args)
        {



            int[] ids = { 17,
53,
66,
99,
100,
101,
113,
116,
118,
120,
122,
126,
130,
133,
136,
139,
172,
228,
246,
339,
348,
370,
408,
421,
467,
498,
527,
528,
550,
585,
589,
596,
603,
605,
606,
686,
688,
691,
693,
697,
698,
700,
703,
710,
712,
740,
772,
774,
785,
845,
851,
853,
980,
982,
1022,
1044,
1064,
1079,
1098,
1122,
1160,
1329,
1449,
1454,
1464,
1535,
1680,
1706,
1715,
1719,
1725,
1776,
1784,
1822,
1833,
1856,
1943,
1953,
1966,
2006,
2008,
2050,
2060,
2061,
2096,
2098,
2120,
2139,
2565,
2606,
2643,
2649,
2782,
2871,
2948,
2983,
3025,
3108,
3109,
3110,
3443,
3561,
3562,
3563,
3565,
3566,
3567,
3652,
3714,
3716,
3742,
4971,
4987,
5108,
5110,
5116,
5171,
5176,
5185,
5211,
5215,
5217,
5221,
5276,
5308,
5394,
5487,
5676,
5697,
5740,
5759,
5782,
5862,
6201,
6343,
6358,
6360,
6487,
6535,
6572,
6725,
6726,
6728,
6742,
6770,
6789,
6807,
6905,
6940,
6949,
6950,
6960,
7101,
7108,
7121,
7288,
7290,
7328,
7384,
7588,
7621,
7645,
7739,
7803,
7806,
7812,
7814,
7855,
7870,
7933,
7948,
7960,
8000,
8004,
8040,
8042,
8122,
8140,
8190,
8211,
8246,
8262,
8264,
8272,
8277,
8292,
8348,
8361,
8364,
8376,
8398,
8435,
8552,
8598,
8676,
8736,
8788,
8809,
8921,
8936,
9081,
9435,
9438,
9456,
9481,
9484,
9552,
9634,
9654,
9739,
9771,
10059,
11014,
11017,
11021,
11366,
11412,
11416,
11417,
11418,
11419,
11420,
11426,
11433,
11443,
11445,
11641,
11649,
11895,
11981,
11986,
11988,
12040,
12042,
12151,
12248,
12258,
12292,
12294,
12323,
12544,
12548,
12685,
12975,
13049,
13326,
13339,
13381,
13491,
13744,
13748,
13750,
13787,
13860,
13874,
13877,
13902,
13903,
13952,
13953,
14105,
14129,
14253,
14517,
14868,
14914,
15038,
15039,
15040,
15041,
15044,
15054,
15091,
15277,
15288,
15653,
15729,
15735,
15743,
15786,
15787,
15867,
15869,
15969,
16067,
16166,
16231,
16429,
16430,
16454,
16511,
16568,
16570,
16583,
16587,
16588,
16592,
17147,
17162,
17177,
17243,
17253,
17286,
17364,
17405,
17618,
17633,
17735,
17738,
17740,
17767,
17877,
17962,
18499,
18562,
20243,
20484,
20572,
20594,
22568,
22812,
23881,
23922,
24394,
22842,
24858,
25046,
31821,
32133,
32135,
32137,
32182,
32266,
32267,
32271,
32272,
32324,
32375,
32421,
32445,
32546,
32654,
32659,
32663,
32674,
32675,
32689,
32690,
32691,
32707,
32709,
32711,
32717,
32734,
32740,
32741,
32770,
32771,
32772,
32773,
32777,
32779,
32859,
32861,
32862,
32863,
32897,
32917,
32926,
32936,
33009,
33051,
33076,
33127,
33147,
33173,
33175,
33206,
33324,
33325,
33463,
33487,
33502,
33554,
33560,
33564,
33570,
33639,
33641,
33679,
33690,
33691,
33763,
33770,
33786,
33910,
33916,
33969,
34017,
34020,
34026,
34035,
34073,
34079,
34086,
34087,
34088,
34089,
34097,
34111,
34119,
34163,
34232,
34254,
34352,
34355,
34379,
34425,
34438,
34449,34477,
34518,
34637,
34722,
34728,
34729,
34759,
34761,
34762,
34763,
34778,
34785,
34787,
34797,
34798,
34809,
34827,
34829,
34861,
34871,
34880,
34944,
34973,
34980,
35013,
35106,
35195,
35197,
35243,
35250,
35261,
35267,
35334,
35335,
35373,
35425,
35571,
35749,
35853,
35891,
35892,
35895,
35913,
35914,
35915,
35917,
35919,
35920,
36004,
36148,
36225,
36276,
36333,
36404,
36447,
36472,
36473,
36476,
36527,
36533,
36541,
36608,
36640,
36713,
36743,
36786,
36828,
36831,
36879,
36881,
36883,
36907,
36911,
36924,
36944,
36984,
37051,
37274,
37488,
37555,
37587,
37624,
37628,
37629,
37727,
37728,
37729,
37788,
37986,
38008,
38032,
38047,
38051,
38085,
38236,
38306,
38370,
38445,
38509,
38539,
38581,
38648,
38649,
38898,
39019,
39272,
39413,
39586,
39588,
39589,
39685,
39902,
40066,
40076,
40084,
40097,
40243,
40366,
40367,
40368,
40444,
40769,
40822,
40823,
40876,
41068,
41072,
41084,
41085,
41186,
41233,
41245,
41246,
41375,
41451,
41455,
41467,
41472,
41475,
41478,
42025,
42317,
42478,
42650,
42653,
42672,
42740,
42955,
43337,
43430,
43509,
43556,
43560,
43612,
43735,
43939,
43987,
44256,
44257,
44286,
44314,
44425,
44457,
44503,
44504,
44520,
44547,
44614,
45027,
45328,
45336,
45362,
45442,
45528,
45664,
45745,
45750,
45902,
46224,
46367,
46442,
46450,
46451,
46452,
46487,
46543,
46565,
46580,
46584,
47278,
47468,
47476,
47484,
47540,
47568,
47731,
47751,
47773,
47784,
47788,
47789,
47902,
47922,
48018,
48168,
48179,
48181,
48262,
48264,
48319,
48438,
48599,
48616,
48707,
48984,
49020,
49063,
49143,
49184,
49195,
49206,
49028,
49358,
49359,
49360,
49361,
49671,
49692,
49753,
49814,
49839,
49847,
49935,
49966,
50090,
50198,
50257,
50348,
50356,
50408,
50409,
50425,
50462,
50521,
50578,
50659,
50672,
50676,
50740,
50750,
50769,
50842,
50905,
50908,
50915,
50977,
50980,
50985,
50997,
51016,
51103,
51271,
51287,
51337,
51339,
51340,
51431,
51489,
51505,
51622,
51678,
51690,
51723,
51729,
51732,
51758,
51763,
51764,
51766,
51779,
51787,
51799,
51806,
51808,
51854,
51877,
51886,
51958,
52011,
52053,
52055,
52144,
521450,
52197,
52201,
52269,
52281,
52358,
52372,
52373,
52499,
52531,
52554,
52592,
52604,
52610,
52660,
52714,
52774,
52814,
52926,
53032,
53114,
53140,
53142,
53209,
53214,
53385,
53563,
53595,
53600,
53616,
54049,
54166,
54193,
54194,
54195,
54237,
54283,
54290,
54303,
54792,
54900,
54904,
55087,
55090,
55233,
55342,
55416,
55426,
55429,
55598,
55625,
55709,
55918,
55987,
56092,
56319,
56520,
56521,
56570,
56686,
56702,
56728,
56730,
56746,
56747,
56748,
56861,
56896,
56897,
57090,
57108,
57143,
57330,
57375,
57412,
57532,
57546,
57609,
57643,
57652,
57774,
57843,
58054,
58153,
58154,
58187,
58291,
58534,
58912,
58916,
58958,
59059,
59202,
59622,
59628,
59792,
59880,
59912,
60103,
60177,
60181,
60182,
60195,
60322,
60540,
60642,
60644,
60793,
60932,
61193,
61295,
61336,
61882,
61914,
62124,
62299,
62321,
62327,
62328,
62346,
62394,
62425,
62426,
62471,
62490,
62608,
62618,
62645,
62695,
62735,
62806,
62809,
62974,
63134,
63138,
63147,
63301,
63560,
63672,
63900,
64044,
64244,
64528,
64664,
64843,
65060,
65063,
65393,
65402,
65407,
65490,
65815,
65816,
65855,
65861,
65864,
65866,
65867,
65880,
65957,
65960,
65990,
65991,
65992,
66009,
66115,
66186,
66218,
66235,
66862,
67171,
67194,
67212,
67219,
67247,
67492,
67518,
67519,
67534,
67794,
68246,
68249,
68250,
68835,
68839,
68847,
68881,
68990,
68993,
69325,
69391,
69401,
69528,
69808,
69809,
69810,
69811,
69867,
70410,
70539,
70645,
70886,
71103,
71249,
71330,
71436,
71489,
71516,
71784,
71956,
71974,
72065,
72066,
72222,
72268,
72484,
73079,
73325,
73393,
73510,
73685,
73872,
73899,
73903,
73920,
73975,
74152,
74392,
74772,
75011,
75015,
75016,
75019,
75160,
75161,
75245,
75413,
75439,
75527,
75528,
75637,
75684,
75698,
75761,
75790,
75823,
75945,
75946,
76110,
76170,
76597,
76664,
77001,
77042,
77130,
77160,
77467,
77575,
77703,
77721,
77722,
78125,
78128,
78183,
78222,
78273,
78675,
78965,
79140,
79206,
79429,
79431,
79564,
79565,
79828,
79830,
79859,
79864,
79866,
79870,
79885,
79914,
79957,
79958,
79962,
79972,
80038,
80151,
80240,
80256,
80263,
80313,
80353,
80966,
81133,
81181,
81276,
81306,
81309,
81430,
81460,
81530,
82531,
82878,
84013,
84014,
84052,
84714,
84838,
85222,
85256,
85288,
85499,
85536,
85948,
86633,
86657,
86659,
86817,
86845,
87238,
87653,
87720,
87762,
88029,
88342,
88345,
88423,
88439,
88625,
88650,
88663,
88771,
89542,
89751,
89792,
89808,
90397,
90398,
90694,
90696,
91624,
91646,
91649,
91704,
91710,
91726,
91727,
91778,
91837,
92157,
92380,
92440,
92700,
92717,
92915,
93044,
93045,
93331,
93402,
93433,
93556,
93581,
93654,
93824,
95917,
96331,
96332,
96346,
96804,
97066,
97071,
97076,
97224,
97386,
97516,
98008,
98474,
98476,
98889,
98994,
99107,
99108,
99109,
99212,
99618,
99939,
100094,
100130,
100780,
100784,
101325,
101399,
101546,
102359,
102063,
102257,
102342,
102351,
102352,
102401,
102543,
102582,
102593,
103904,
104316,
104773,
105174,
105289,
105762,
105809,
106718,
106830,
106832,
106951,
107428,
107574,
107865,
108172,
108212,
108270,
108271,
108273,
108280,
108839,
108416,
108442,
108978,
109223,
109304,
110326,
110744,
110968,
111341,
111398,
111580,
111673,
111771,
111859,
111895,
111896,
111897,
111898,
112866,
112867,
112868,
112869,
112870,
112921,
112927,
112948,
113190,
113355,
113656,
113698,
113724,
114014,
114049,
114158,
114163,
114165,
114282,
114479,
114724,
114730,
114738,
114923,
115072,
115078,
115151,
115178,
115181,
115236,
115268,
115276,
115284,
115310,
115356,
115450,
115625,
115746,
115748,
115770,
115778,
115781,
115831,
115840,
115842,
115843,
115844,
116011,
116095,
116470,
116670,
116694,
116847,
116849,
118000,
118552,
118638,
118779,
118903,
118940,
119414,
119661,
119732,
119898,
119899,
120145,
120146,
120360,
120455,
120517,
120679,
121253,
121471,
121936,
122065,
123040,
123904,
124280,
124682,
125011,
125021,
125278,
125290,
125517,
126135,
126371,
128077,
128658,
128999,
129534,
130654,
130736,
130958,
131447,
131559,
131894,
132410,
132467,
132620,
132621,
133889,
133890,
133939,
134611,
134664,
136209,
136426,
136506,
136509,
136748,
136764,
136828,
137619,
138333,
138334,
138443,
138537,
138815,
139414,
140274,
141264,
141386,
141423,
141428,
142651,
143343,
143356,
143380,
143503,
143591,
143872,
144400,
145044,
145067,
145205,
145297,
145325,
145357,
145481,
145485,
145626,
145665,
146715,
147089,
147102,
147518,
147525,
147533,
150289,
151506,
152118,
152150,
152173,
152175,
152242,
152262,
152280,
152830,
153561,
153595,
153626,
153794,
154058,
154193,
155080,
155209,
155213,
155361,
155998,
156112,
156179,
156197,
156240,
156366,
156390,
156601,
156681,
156816,
156877,
156910,
157153,
157695,
157757,
158008,
158136,
158315,
158338,
158599,
158704,
158719,
158728,
159996,
160165,
162243,
162495,
162794,
164264,
164583,
164812,
164896,
164906,
165314,
165962,
167105,
167332,
168941,
168962,
170176,
170852,
171030,
171138,
171156,
171654,
171720,
171950,
172108,
175366,
175900,
175984,
176204,
176242,
176244,
176246,
176248,
177192,
177193,
177269,
177288,
177393,
177599,
178740,
179546,
180163,
180224,
180374,
180850,
181138,
181197,
181597,
182006,
182952,
183123,
183160,
183218,
183242,
183569,
183601,
183649,
183705,
183998,
184059,
184092,
184110,
184114,
184201,
184202,
184367,
184575,
185068,
185075,
185088,
185311,
185313,
185373,
185438,
185497,
185565,
185763,
185855,
185901,
186202,
186265,
186270,
186289,
186387,
186389,
186470,
186608,
186987,
187190,
187350,
187708,
187874,
188068,
188089,
188114,
188499,
188719,
188927,
189223,
189524,
190090,
190229,
190232,
190319,
190456,
190816,
190852,
190928,
191433,
191747,
191837,
192058,
192081,
192083,
192687,
192759,
192923,
193017,
193152,
193213,
193261,
193315,
193316,
193396,
193440,
193455,
193530,
193753,
193754,
193755,
193757,
193758,
193759,
193779,
193786,
193796,
193807,
193808,
193826,
193924,
194098,
194183,
194199,
194223,
194392,
194407,
194436,
194462,
194466,
194509,
194679,
194844,
194855,
194913,
194918,
195131,
195182,
195292,
195451,
195452,
195467,
195586,
195615,
195621,
196021,
196166,
196256,
196257,
196259,
196261,
196277,
196447,
196638,
196725,
196736,
196770,
196834,
196884,
196932,
196937,
197021,
197041,
197211,
197214,
197346,
197393,
197395,
197628,
197650,
197835,
197995,
198034,
198067,
198068,
198245,
198304,
198456,
198457,
198458,
198459,
198460,
198461,
198463,
198465,
198466,
198467,
198468,
198469,
198471,
198472,
198589,
198670,
198838,
198929,
198590,
199019,
199130,
199176,
199261,
199455,
199500,
199715,
199786,
199795,
199804,
199890,
199953,
199954,
200025,
200108,
200136,
200163,
200264,
200418,
200642,
200652,
200758,
200806,
200829,
200850,
200851,
200854,
201060,
201078,
201427,
201467,
201473,
201729,
201776,
201897,
201898,
202028,
202077,
202085,
202161,
202168,
202286,
202360,
202385,
202495,
202665,
202767,
202768,
202771,
202800,
202895,
202940,
202942,
203155,
203242,
203286,
203415,
203524,
203576,
203651,
203702,
203720,
203757,
203783,
204018,
204019,
204021,
204035,
204065,
204081,
204147,
204197,
204263,
204293,
204330,
204331,
204488,
204945,
205021,
205025,
205029,
205030,
205032,
205065,
205179,
205180,
205191,
205223,
205234,
205273,
205320,
205393,
205406,
205495,
205523,
205545,
205588,
206237,
206328,
207068,
207144,
207158,
207215,
207230,
207246,
207256,
207311,
207317,
207343,
207349,
207387,
207399,
207407,
207583,
207604,
207736,
207777,
207778,
207946,
208065,
208253,
208323,
208464,
208652,
208717,
208729,
208778,
209069,
209202,
209258,
209261,
209566,
209577,
209683,
209782,
209794,
209795,
209842,
209997,
210081,
210152,
210191,
210247,
210301,
210666,
210702,
210705,
210722,
210726,
210984,
211048,
211053,
211073,
211619,
211714,
211727,
211740,
211766,
211881,
211970,
211989,
212036,
212044,
212048,
212051,
212056,
212084,
212283,
212333,
212338,
212383,
212384,
212436,
212459,
212552,
212653,
212726,
212744,
212869,
212994,
213043,
213045,
213075,
213241,
213398,
213435,
213522,
213610,
213634,
213644,
213721,
213757,
213764,
214074,
214077,
214098,
214202,
214326,
214330,
214579,
214621,
214903,
214904,
214906,
214907,
214909,
214910,
214911,
214912,
214913,
214915,
214916,
214917,
214918,
214919,
214920,
214921,
214922,
214923,
214924,
214925,
214927,
214928,
214929,
214930,
214931,
214932,
214933,
214934,
214935,
214936,
214937,
214939,
215258,
215373,
215377,
215661,
215854,
216008,
216318,
216516,
216695,
216698,
217020,
217200,
217814,
218256,
218281,
218679,
218713,
218838,
219091,
219202,
219698,
219700,
219707,
219906,
220255,
220340,
220584,
220645,
220651,
220655,
220658,
220662,
220663,
220679,
220681,
220683,
220684,
220690,
220691,
220692,
220693,
220694,
220696,
220699,
220701,
220703,
220705,
220706,
220708,
220709,
220710,
220712,
220715,
220718,
220724,
220729,
220731,
220732,
220734,
221164,
221202,
221565,
221703,
222122,
222299,
222395,
222398,
222401,
222412,
222423,
222426,
222427,
222430,
222431,
222601,
222602,
222609,
222610,
222611,
222612,
222651,
222660,
223306,
223565,
223917,
224716,
224668,
224869,
224871,
225254,
225379,
226024,
226194,
226277,
226407,
227045,
227082,
227102,
227154,
227160,
227225,
227847,
228260,
228477,
228755
            };

            List<int> spellids = new List<int>(ids);
            ApiLocales locales = new ApiLocales();
            List<Spell> spells = new List<Spell>();


            WebClient client = new WebClient() { Encoding = Encoding.UTF8 };
            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (int i in spellids)
            {

                string downloadstring = "https://us.api.battle.net/wow/spell/";

                string locale = "locale=en_US";
                //int spellid = 192801;

                string compiledstring = $"{downloadstring}{i}?{apikey}&{locale}";

                // Download string.
                try
                {
                    string value = client.DownloadString(compiledstring);

                    //// Write values.
                    //Console.WriteLine("--- WebClient result ---");
                    //Console.WriteLine(value.Length);
                    //Console.WriteLine(i);

                    Spell tempSpell = JsonConvert.DeserializeObject<Spell>(value);
                    bool test = string.IsNullOrWhiteSpace(tempSpell.powerCost);
                    // Console.WriteLine($"{tempSpell.id} has no Powercost {test.ToString()}");

                    //if (isPlayerSpell(tempSpell))
                    //{
                    spells.Add(tempSpell);
                    //}
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    //do nothing with the spell.
                }
            }
            //process spells
            foreach (Spell p in spells)
            {
                //Console.WriteLine($"{p.id} {p.name} {p.description}");

                foreach (ApiLocale l in locales.Info)
                {
                    if (l.GameLocale != "enUS")
                    {
                        try
                        {
                            string lstring = $"{l.Api}{p.id}?{apikey}&{l.Locale}";
                            string result = client.DownloadString(lstring);
                            Spell localspell = JsonConvert.DeserializeObject<Spell>(result);
                            //Console.WriteLine($"{localspell.id} obtained from  {l.Locale}");
                            l.addSpell(localspell);
                        }
#pragma warning disable CS0168 // Variable is declared but never used
                        catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                        {
                            //do nothing with the spell.
                        }

                    }
                    else
                    {
                        l.addSpellList(spells);
                    }
                    
                }
                //Console.WriteLine(p.id);
            }

            //write files
            StreamWriter csv = File.CreateText("spellidlist.csv");
            foreach (ApiLocale l in locales.Info)
            {
                string forwardfilename = l.GameLocale + ".lua";
                string reversefilename = l.GameLocale + "HASH.lua";
                string shadowfilename = l.GameLocale + "SHADOW.lua";

                StreamWriter fw = File.CreateText(forwardfilename);
                StreamWriter rw = File.CreateText(reversefilename);
                StreamWriter sw = File.CreateText(shadowfilename);

                if (l.GameLocale == "enUS")
                {
                    csv.WriteLine("\"spellID\",\"Name\",\"Description\"");
                }

                
                fw.WriteLine("local GSE = GSE");
                rw.WriteLine("local GSE = GSE");
                sw.WriteLine("local GSE = GSE");
                fw.WriteLine("local Statics = GSE.Static");
                rw.WriteLine("local Statics = GSE.Static");
                sw.WriteLine("local Statics = GSE.Static");
                fw.WriteLine("");
                rw.WriteLine("");
                sw.WriteLine("");
                fw.WriteLine("GSE.TranslatorLanguageTables[Statics.TranslationKey][\"" + l.GameLocale + "\"] = {");
                rw.WriteLine("GSE.TranslatorLanguageTables[Statics.TranslationHash][\"" + l.GameLocale + "\"] = {");
                sw.WriteLine("GSE.TranslatorLanguageTables[Statics.TranslationShadow][\"" + l.GameLocale + "\"] = {");

                foreach (Spell s in l.Spells)
                {
                    fw.WriteLine("	[" + s.id + "] = \"" + s.name.Replace('"', '\"') + "\",");
                    rw.WriteLine("	[\"" + s.name.Replace('"', '\"') + "\"] = " + s.id + ",");
                    sw.WriteLine("	[\"" + s.name.ToLower().Replace('"', '\"') + "\"] = " + s.id + ",");
                    if (l.GameLocale == "enUS")
                    {
                        csv.WriteLine($"{s.id},\"{s.name}\",\"{s.description}\"");
                    }
                }
                fw.WriteLine("}");
                rw.WriteLine("}");
                sw.WriteLine("}");

                fw.Close();
                rw.Close();
                sw.Close();
                
            }
            csv.Close();



        }

        private static bool isPlayerSpell(Spell s)
        {
            bool result = false;
            Regex r = new Regex(".*?(artifact)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(s.icon);
            if (m.Success)
            {
                result = true;
            }
            else if (!(String.IsNullOrWhiteSpace(s.description)) && s.castTime != "Passive" && !(String.IsNullOrWhiteSpace(s.powerCost)))
            {
                result = true;
            }

            return result;

        }

    }
}

