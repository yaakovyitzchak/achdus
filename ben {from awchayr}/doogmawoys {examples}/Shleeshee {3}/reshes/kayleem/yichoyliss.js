(function() {
	Object.defineProperties(YICHOYLISS, {
		Osios: {
                get: () => (new function() {
					var oys = "אבגדהוזחטיכךלמםנןסעפףצץקרשתְֱֲֳִֵֶַָֹֺֻּֽ",
						numbs = [
							1488,
							1489,
							1490,
							1491,
							1492,
							1493,
							1494,
							1495,
							1496,
							1497,
							1499,
							1498,
							1500,
							1502,
							1501,
							1504,
							1503,
							1505,
							1506,
							1508,
							1507,
							1510,
							1509,
							1511,
							1512,
							1513,
							1514,
							1456,
							1457,
							1458,
							1459,
							1460,
							1461,
							1462,
							1463,
							1464,
							1465,
							1466,
							1467,
							1468,
							1469
						],
						eng = [
							"Aleph",
							"Bays",
							"Gimel",
							"Dales",
							"Hey",
							"Vuhv",
							"Zaeein",
							"Ches",
							"Tes",
							"Yood",
							"Chawf",
							
							"Lamed",
							"Mem",
							
							"Noon",
							
							"Sawmech",
							"Aeein",
							"Fay",
							
							"Tzadeek",
							
							"Koof",
							"Raysh",
							"Shin",
							"Suhf",
							"Final_Chawf",
							"Final_Mem",
							"Final_Noon",
							"Final_Fay",
							"Final_Tzadeek",
							"Koobootz",
							
							
						],
						actshual = oys
					
					
					var gematriaMap = {
						1: "א",
						2: "ב",
						3: "ג",
						4: "ד",
						5: "ה",
						6: "ו",
						7: "ז",
						8: "ח",
						9: "ט",
						10: "י",
						20: "כ",
						30: "ל",
						40: "מ",
						50: "נ",
						60: "ס",
						70: "ע",
						80: "פ",
						90: "צ",
						100: "ק",
						200: "ר",
						300: "ש",
						400: "ת",
						500: "ך",
						600: "ם",
						700: "ן",
						800: "ף",
						900: "ץ"
					}
					var isEnglish = false
					if(oys[0].charCodeAt(0) !== 1488){
						isEnglish = true
						actshual = eng.join("$")
						var maftaychos = Object.keys(gematriaMap)
						gematriaMap = Object.fromEntries(
							eng.map((e, i) => (
								[
									maftaychos[i],
									eng[i]
								]
							))
						)
					}
					this.gematria = nm => {
						if(typeof(nm) == "number") {
							return (function numberificly(nm) {
								var noom = nm.toString();
								var places = [], i, k,
									digits = "1234567890",
									full = "",
									finished = 0
								for(i = 0; i < noom.length; i++) {
									full = ""
									var restOfLength = noom.length - i;
									for(k = 0; k < restOfLength - 1; k++) {
										full += 0
									}
									full = noom[i] + full
									finished = parseInt(full)
									
									places.push(finished)
									
								}
								places = places.map(y => {
									var x = y;
									if(x > 900) {
										var cur = x;
										var arr = []
										for(i = x; i >= 0; i--) {
											var it = x - 900
											if(it >= 0) {
												arr.push(900)
												x = it
											} else {
												arr.push(numberificly(x))
												break
											}
											
											
											
										}
										return arr.flat()
									}
									return x
								})
								return places.flat().filter(x => x)
							})(nm).map(x => (
								gematriaMap[x]
							)).join(
								isEnglish ? "$" 
								: ""
							)
							
						} else if(typeof(nm) == "string") {
							var list = actshual.split(
								isEnglish ? "$" :
								""
							)
							var words = nm.split(" ")
							var lettersInWords = words.map(w => (
								w.split(
									isEnglish ? "$" :
									""
								)
							))//.filter(x => x)
							var keys = Object.keys(gematriaMap),
								vals = Object.values(gematriaMap)
							var numbersFromLetters = lettersInWords.map((y) => 
								y.map(x => 
									(vals.includes(x)) ? 
										keys[vals.indexOf(x)]
									: ""
								).join(".")
							).join(" ")//.filter(x => x)

							return numbersFromLetters
						}
					}
					
					this.toString = () => 
						actshual
				})
				
        },
		Shaym: {
			get: () => () => {
				var rez = "", i;
				for(i = 0; i < (Math.random() + 10) * 10; i++) {
					rez += (o => 
						o[
							Math.floor(
								Math.random() * 
								o.length
							)
						]
					)(YICHOYLISS.Osios.toString().split(""))
				}
				return rez
			}
		},
		HtmlNode: {
			get: () => function(opts) {
				var tag = opts.tag || "div",
					el = document.createElement(tag),
					parent = opts.parent || document.body,
					exclusions = "tag events attributes children",
					map = {
						events: (obj) => {
							
							el.addEventListener(event, fnc)
						},
						attributes: (name, value) => {
							el.setAttribute(name, value)
						},
						children(otherArray) {
							otherArray.forEach(x => {
								new YICHOYLISS.HtmlNode({
									...x,
									parent: el
									
								})
							})
						}
					}
				
			//	parent.appendChild(el)
				Object.entries(opts).forEach(x => {
					if(!exclusions.split(" ").includes(x[0])) {
						el[x[0]] = x[1]
					}
				})
				
				Object.entries(map).forEach(x => {
					if(opts[x[0]]) {
						x[1](opts[x[0]])
					}
				})
				
				if(typeof(opts.heesCheel) == "function") {
					opts.heesCheel(el)
				}
				
			}
		},
		Gavvan: {
			get: () => function col(op) {
				var rez = {r:0, g: 0, b: 0}
				if(typeof(op) == "object") {
					for(var k in op) {
						if(rez[k] !== undefined) {
							if(typeof(op[k]) == "number") {
								rez[k] = op[k]
							}
						}
					}
				} else if(typeof(op) == "string") {
					if(window.THREE) {
						var colObj = new THREE.Color(op)
						colObj = col(colObj)
						rez = colObj
					}
				}
				return rez
			}
		},
		Chochmah: {
			get: () => function(opts = {}) {
				var events = {}
				Object.defineProperties(this, {
					on: {
						get: () => (name, func) => {
							if(!events[name]) events[name] = []
							events[name].push((...data) => {
								if(typeof func == "function") {
									func(...data)
								}
							})
						}
					},
					events: {
						get: () => () => events
					},
					machehPeulos: {
						get: () => (name) => {
							name ? (events[name] = []) 
							: events = {}
						}
					},
					eventNames: {
						get:() => Object.keys(events)
					},
					ayshPeula /*fireEvent*/: {
						get: () => (name, ...data) => {
							var it = events[name]
							if(it) {
								it.forEach(x => {
									x(...data)
								})
							}
						}
					}
				})
			}
		},
		ChayoosShoymayr: {
			get: () => function(opts) {
				YICHOYLISS.Chochmah.call(this, ...arguments)
				var makor,
					startZman = 0,
					hoyvehZman = 0,
					meedosLiShomayr = [],
					maftaychosShelChayoos = [],
					
					hoyvehChayoos,
					hoyvehChayoosZman = 0,
					heesCheelChayoosZman = 0,
					currentChayoosIndex, 
					nextChayoosIndex, 
					chayoosMakor,
					i, c, n, rez, rezObj,
					zeh = null, co = null, rz, az, factor,
					startedPlaying = false
				this.on("heesCheel", saychil => {
					makor = saychil.makor
					meedosLiShomayr = saychil.meedos
					startZman = Date.now()
				})
				
				this.on("chayoosMaftayach",  () => {
					hoyseefChayoosMaftayach()
				})
				
				this.on("poysayk", () => {
					if(maftaychosShelChayoos % 2 !== 0)
						hoyseefChayoosMaftayach()
					this.ayshPeula("siyaym", maftaychosShelChayoos)
				})
				
				
				this.on("heesCheelLiChoyzayrBiZman", saychil => {
					hoyvehChayoos = saychil.chayoos
					chayoosMakor = saychil.makor
					startedPlaying = true
				})
				
				this.on("hissHavoos", dealtuh => {
					if(startedPlaying) {
						startedPlaying = false;
						heesCheelChayoosZman = Date.now()
					}
					hoyvehChayoosZman = (
						Date.now() - 
						heesCheelChayoosZman
					);
					if(is(hoyvehChayoos, "Array")) {
						
						window.hc = hoyvehChayoos
						var isBreak = false
						for(
							i = currentChayoosIndex || 0;
							i < hoyvehChayoos.length - 1;
							i++
						) {
							
							c = hoyvehChayoos[i]
							n = hoyvehChayoos[i + 1]
							currentChayoosIndex = null;
							nextChayoosIndex = null;
							
							if(
								c.zman <= hoyvehChayoosZman &&
								n.zman >= hoyvehChayoosZman
							) {
								currentChayoosIndex = i;
								nextChayoosIndex = i + 1;
								isBreak = true
							}
							
							if(
								currentChayoosIndex !== null &&
								nextChayoosIndex    !== null 
							//	&& chayoosMakor
							) {

								var propsCurrent = (
									mischuhshayvMeedosBiHoyveh(
										c,
										n,
										hoyvehChayoosZman,
										dealtuh
									)
								)
								
								
								Object.keys(propsCurrent).forEach(m => {
									this.ayshPeula("chayoosChadash", {
										maftayach: m,
										chasheevoos: propsCurrent[m]
									})
									
								})
								console.log("yes", propsCurrent,
									hoyvehChayoosZman
								)
							} else {
							/*	console.log("?!",currentChayoosIndex,
								nextChayoosIndex,i,c.zman,hoyvehChayoosZman,
								n.zman
								)*/
							}
							if(isBreak) {
								break;
							}
						}
						
						
					}
				})
				
				function mischuhshayvMeedosBiHoyveh(rayshees, acharees, zman) {
					rezObj = {}
					az = acharees.zman
					rz = rayshees.zman
					Object.keys(rayshees.meedos).forEach(k => {
						rez = {}
						rezObj[k] = rez
						Object.keys(rayshees.meedos[k]).forEach(kk => {
							zeh = rayshees.meedos[k][kk]
							co = acharees.meedos[k][kk]
							
							if(zeh !== null && co !== null) {
								
								factor = (
									(
										zman - rz
									)
										/ 
									(
										az - rz
									)
								)
								
								rez[kk] = (
									zeh + (co - zeh) * factor
								)
								
							}
							
							/*
							 percent = current / total
							 percent of 7 between 5 and 10?
							 well percent of 6 between 0 and 10 is
							 6 / 10
							 
							 but between 5 and 10
							 
							 it can't be 7 / 10
							 
							 really the total of between 5 and 10 is 5
							 
							 so 7 percent of between 5 and 10 is really
							 
							 the total amount, after 5, that it's complete
							 
							 so (7 - 5) / (10 - 5) or 2 / 5, should be the same
							 percent as the percent of 7 in the interval of
							 5 and 10
							 
							 so the percentage of p in (intervalStart, intervalEnd)
							 is (p - intervalStart) / (intervalEnd - intervalStart)
							 
							 once have the percentage
							 
							 how do we convert it back
							 given a percentage in an interval, like above
							 and given a second interval, with a start and end
							 how do we calculate the percentage amount
							 in the second interval
							 such that it matches the percentage amount
							 in the first interval...
							 
							 so in the above example, lets change it to
							 the value of 6 from 4 to 10
							 so that would be (6 - 4) / (10 - 4)
							 or
							 2 / 6 = 1 / 3
							 
							 now, if we have a second interval, 3 to 7, how 
							 do we calculate the value that is 1/3 of the way
							 between 3 and 7?
							 
							 ...................................
							 
							 well the interval of 3 and 7
							 is really the same distance as (3 - 3) to (7 - 3) or
							 0 to 4
							 to to calculate 1/3 of 4, just multiple 1/3 * 4
							 then to find how far that is between 3 and 7, just
							 add it back to 3 so 
							 3 + (7 - 3) * 1 / 3
							 should be 1 / 3 of the way between 3 and 7
							 so given a factor, and a start and an end, to calculate
							 the current value,
							 it is:
							 start + (end - start) * factor
							*/
							
							
						});
					})
					return rezObj
				}
				
				function hoyseefChayoosMaftayach() {
					console.log("WHAT?!", makor)
					if(makor && makor.chootify) {
						hoyvehZman = Date.now() - startZman
						if(meedosLiShomayr) {
							var makorMeedos = makor.chootify(
								meedosLiShomayr
							)
							
							maftaychosShelChayoos.push({
								zman: hoyvehZman,
								...(
									makorMeedos ? 
										{
											meedos: makorMeedos
										}
									: false
								)
							})
						}
					}
				}
			}
		},
		Heeoolee: {
			get: () => function(opts = {}) {
				YICHOYLISS.Chochmah.call(this, ...arguments)
				
				var listeners = opts.listeners || {}
				Object.keys(listeners).forEach(k => {
					if(typeof(listeners[k]) == "function") {
						this.on(k, listeners[k])
					} else if(listeners[k].constructor.name == "Array") {
						
						listeners[k].forEach(x => {

							this.on(k, x);
						})
					}
				})
				this.listeners = listeners;
				
				var dafeem = {},
					defaults = [];
				
				Object.defineProperties(this, {
					chootify: {
						get: () => (
							props
						) => {
							
							if(!is(props, "Array")) {
								props = this.yesodos || []
							}
							
							/*if(!props.includes("sayfur")) {
								if(this.minyanDafeem() > 0) {
									props.push("sayfur")
								}
							}*/
							
							var ownProps = (
								
								Object.
								getOwnPropertyNames(this)
							).filter(x => (
								props.includes(x)
							)),
								result = {}
							
							ownProps.forEach(x => {
								var current = this[x]
								if(is(this[x], "Array")) {
									var old = current
									
									current = old.map(prop => 
										typeof(prop.chootify) ==
										"function" ? 
										prop.chootify() :
										null
									)
								}
								
								if(
									typeof(current) ==
										"object"
								)
								var otherProps = (
									current.yesodos || 
									Object
									.getOwnPropertyNames(
										current
									)
								)
								result[x] = (
								typeof(current) != "undefined" ?
									typeof(current.chootify) ==
									"function" ? 
									current.chootify(otherProps) :
									current
								: null
								)
							})
							
							
							return (result);
							
							
						}
					},
					minyanDafeem: {
						get: () => () => {
							var i = 0, k
							for(k in dafeem) {
								i++
							}
							return i;
						}
					},
					
					yesodos: {
						get: () => defaults
					},
					hoyseefYesod: {
						get: () => shaym => {
							if(typeof(shaym) == "string") {
								var exists = defaults.indexOf(shaym) > -1
								if(!exists) {
									defaults.push(shaym)
								}
							}
						}
					},
					hoyseefYesodos: {
						get: () => arr => {
							if(is(arr, "Array")) {
								arr.forEach(d => {
									this.hoyseefYesod(d)
								})
							} else {
								this.ayshPeula("teekoon", {
									soog: "teekoonOsios",
									teekoon: "not chooteem!"
								})
								return false;
							}
						}
					},
					koysayvDaf: {
						get: () => (shaym, toychen) => {
							if(
								typeof(shaym) == "string" &&
								typeof(toychen) == "string"
							) {
								dafeem[shaym] = toychen
								return true;
							} else {
								this.ayshPeula("teekoon", {
									soog: "teekoonOsios",
									teekoon: "not chooteem!"
								})
								return false;
							}
						}
					},
					motzayDaf: {
						get: () => shaym => (
							(typeof(shaym) == "string") &&
								dafeem[shaym] || null
						)
					},
					misakaynDaf: {
						get: () => (shaym, chadash) => {
							var it = dafeem[shaym]
							if(it) {
								if(typeof(chadash) == "string") {
									dafeem[shaym] = chadash
								} else {
									this.ayshPeula("teekoon", {
										soog: "teekoonOsios",
										teekoon: e
									})
								}
							} else {
								this.ayshPeula("teekoon", {
									soog: "teekoonDaf",
									teekoon: e
								})
							}
						}
					},
					korayDaf: {
						get: () => shaym => {
							var it = dafeem[shaym]
							if(it) {
								
								var fnc;
								try {
									fnc = Function("self", it)
								} catch(e) {
									this.ayshPeula("teekoon", {
										soog: "teekoonSofreem",
										teekoon: e
									})
								}
								
								if(fnc) {
									try {
										fnc(this)
									} catch(e) {
										this.ayshPeula("teekoon", {
											soog: "ratzZmanTeekoon",
											teekoon: e
										});
									}
								}
							}
						}
					},
					michayDaf: {
						get: () => shaym => {
							var it = dafeem[shaym]
							if(it) {
								delete dafeem[shaym]
							}
						}
					},
					sayfur: {
						get: () => dafeem
					},
					daf: {
						get: () => d => {
							if(typeof(d) == "object") {
								this.koysayvDaf(d.shaym, d.toychen)
								this.korayDaf(d.shaym)

							}
						}
					}
				})
				
				
				var dafeems = opts.dafeem;
				var daf = opts.daf
				if(typeof(daf) == "object") {
					this.daf(daf)
				}
				
				if(is(dafeems, "Array")) {
					dafeems.forEach(d => {
						this.daf(d)
					})
				}

				this.ayshPeula("neeoor", this)
			}
		},
		Kav: {
			get: () => function(opts = {}) {
				YICHOYLISS.Heeoolee.call(this, ...arguments)
				var self = this
				if(typeof(opts) != "object") opts = {}
				var propsNames = (
					
					Object.keys(opts) || []
				),
					props = {}
				
				propsNames.forEach(p => {
					var ownProps = (
						Object.
						getOwnPropertyNames(this)
					)
					!ownProps.includes(p) && (() => {
						Object.defineProperty(this, p, {
							get: () => props[p],
							set: v => {
								self.ayshPeula(
									"set", {
										property: p,
										value: v
									}
								)
								props[p] = v
							}
						})
						this[p] = opts[p]
					})()
				})
				
				this.hoyseefYesodos(propsNames)
			}
		},
		Davar: {
			get: () => function(opts = {}) {
				YICHOYLISS.Heeoolee.call(this, ...arguments)
				
				
				
				var self = this
				if(typeof opts.meen == "string") {
					this.meen = opts.meen
				}
				
				if(typeof opts.meenim == "object") {
					this.meenim = (
						Array.apply(0, opts.meenim)
					).filter(x => typeof(x) == "string");
				}
				
				var kavProps = {
					"position": 0,
					"rotation":0,
					"scale":3,
					"quaternion":0
				},
					subProps = "xyz".split(""),
					kavPropNames = Object.keys(kavProps),
					actualKaveem = {}
					
				kavPropNames.forEach(kp => {
					var it = opts[kp]
					
					Object.defineProperty(this, kp, {
						get: () => actualKaveem[kp],
						set: v  => {
							var obj = Object.fromEntries(
								subProps.map(sp => [
									sp, 0
								])
							),
								kav = new YICHOYLISS.Kav(
									obj
								)
							kav.on("set", props => {
								self.ayshPeula("set", {
									property: kp,
									subProperty: (
										props.property
									),
									value: (
										props
										.value
									)
								}, this)
							})
							actualKaveem[kp] = (
								kav
							)
							
							if(typeof(v) == "number") {
								subProps.forEach(sp => {
									
									kav[sp] = v
								})
							}
							
							if(typeof(v) == "object") {
								Object.keys(v).forEach(k => {
									kav[k] = v[k]
								})
							}
						}
					})
					var that = typeof(it) 
							!= "undefined" ?  it : null
					this[kp] = (
						(that !== null && that) || 
						kavProps[kp]
					)
					
				})
				
				this.ayshPeula("keema", this);
			}
		},
		Taroves: {
			get: () => function(opts = {}) {
				YICHOYLISS.Heeoolee.call(this, ...arguments)
				
				var type = opts.type || opts.basic,
					base = opts.base,
					map = opts.map || {},
					defArgs = [1,1,1],
					arguments2 = opts.arguments || opts.args || defArgs
					
				if(arguments2) {
					if(arguments2.constructor.name !== "Array") {
			//			arguments2 = [arguments2]
					}
				}
				var found = map[type],
					pashut, constructor, myArgs
					
				if(window[base]) {
					var it = window[base][found]
					if(it) {
						constructor = it
						myArgs = arguments2
						
					} else if(base[opts.basic]) {
						constructor = it
						myArgs = defArgs
					
					}
					
					Object.defineProperties(this, {
						malchus: {
							get: () => () => !pashut ? (
								pashut = new constructor(...myArgs) 
							) : pashut
							|| null
						},
						constructor: {
							get: () => constructor
						},
						arguments: {
							get: () => myArgs
						},
						type: {
							get: () => type
						},
						found: {
							get: () => found
						},
						base: {
							get: () => base
						}
					})
				}
			}
		},
		Chomer: {
			get: () => function(opts = {}) {
				YICHOYLISS.Taroves.call(this, {
					...opts,
					basic: "boxBuffer",
					base: "THREE",
					map: {
						"boxBuffer": "BoxBufferGeometry",
						"box": "BoxGeometry",
						"circleBuffer": "CircleBufferGeometry",
						"circle": "CircleGeometry",
						"coneBuffer": "ConeBufferGeometry",
						"cone": "ConeGeometry",
						"cylinderBuffer": "CylinderBufferGeometry",
						"cylinder": "CylinderGeometry",
						"dodecahedronBuffer": "DodecahedronBufferGeometry",
						"dodecahedron": "DodecahedronGeometry",
						"edges": "EdgesGeometry",
						"extrudeBuffer": "ExtrudeBufferGeometry",
						"extrude": "ExtrudeGeometry",
						"icosahedronBuffer": "IcosahedronBufferGeometry",
						"icosahedron": "IcosahedronGeometry",
						"latheBuffer": "LatheBufferGeometry",
						"lathe": "LatheGeometry",
						"octahedronBuffer": "OctahedronBufferGeometry",
						"octahedron": "OctahedronGeometry",
						"parametricBuffer": "ParametricBufferGeometry",
						"parametric": "ParametricGeometry",
						"planeBuffer": "PlaneBufferGeometry",
						"plane": "PlaneGeometry",
						"polyhedronBuffer": "PolyhedronBufferGeometry",
						"polyhedron": "PolyhedronGeometry",
						"ringBuffer": "RingBufferGeometry",
						"ring": "RingGeometry",
						"shapeBuffer": "ShapeBufferGeometry",
						"shape": "ShapeGeometry",
						"sphereBuffer": "SphereBufferGeometry",
						"sphere": "SphereGeometry",
						"tetrahedronBuffer": "TetrahedronBufferGeometry",
						"tetrahedron": "TetrahedronGeometry",
						"textBuffer": "TextBufferGeometry",
						"text": "TextGeometry",
						"torusBuffer": "TorusBufferGeometry",
						"torus": "TorusGeometry",
						"torusKnotBuffer": "TorusKnotBufferGeometry",
						"torusKnot": "TorusKnotGeometry",
						"tubeBuffer": "TubeBufferGeometry",
						"tube": "TubeGeometry",
						"wireframe": "WireframeGeometry"
					}
				})
				
			}
		},
		Tzurah: {
			get: () => function(opts = {}) {
				if(!opts.mt || opts.empty) {
				YICHOYLISS.Taroves.call(this, {
					...opts,
					basic: "basic",
					base: "THREE",
					map: {
						basic: "MeshBasicMaterial",
						depth: "MeshDepthMaterial",
						distance: "MeshDistanceMaterial",
						lambert: "MeshLambertMaterial",
						matcap: "MeshMatcapMaterial",
						normal: "MeshNormalMaterial",
						phong: "MeshPhongMaterial",
						physical: "MeshPhysicalMaterial",
						standard: "MeshStandardMaterial",
						toon: "MeshToonMaterial",
						points: "MeshPointsMaterial",
						rawShader: "RawShaderMaterial",
						shaderMaterial: "ShaderMaterial",
						shadowMaterial: "ShadowMaterial",
						spriteMaterial: "SpriteMaterial"
					}
				})
				} else {
					console.log("WOW")
					return null;
					
				}
				
			}
		},
		Nivra: {
			get: () => function(opts = {}) {
				var loaded = false
				var onloadedFunctions = []
				var otherListeners = (
									opts.arguments &&
									opts.arguments.listeners ||
									opts.listeners
								),
					lastened = addFunctionsAsArrayToObject(
							{
								...(
									otherListeners
								)
							},
							{
								neeoor(){},
								loaded(self) {
								
									loaded = true
									onloadedFunctions.forEach(x => {
										x()
									})
							
								},
								ready: funct => (
									(tmp => 
										!loaded ? 
											onloadedFunctions.push(tmp)
										: tmp()
									)(() =>
										typeof(funct) == "function" ?
											funct()
										:	(()=>{
											console.log("this " + 
											funct + 
											"isn't a function?!")
										})()
									)
								),
								set(data, self) {
									var tmp = data => {
										
										(pash => 
											pash
											[data.property]
											[data.subProperty] = data.value
										)(self.pashut || {})
									}
									if(loaded) tmp(data)
									else onloadedFunctions.push(() => tmp(data))
								}	
							}
						)
				
				var tar = new YICHOYLISS.Taroves({
					...opts,
					map: {
						domem: "Domem",
						ohr: "Ohr",
						ayin: "Ayin"
					},
					basic: "domem",
					base: "YICHOYLISS",
					arguments: {
						...opts,
						listeners: lastened
					}
				})
				var oldOpts = opts;
				
			//	this.on("getOpts", () => oldOpts)
				
				
					if(tar.constructor && tar.arguments) {
						tar.constructor.call(this, tar.arguments);

					}
					
				
				
				
			}
		},
		
		Domem: {
			get: () => function(opts = {}) {
				YICHOYLISS.Davar.call(this, ...arguments);
				var pawsh = opts.pashut
				var self = this
				this.hoyseefYesodos([
					"position",
					"rotation",
					"scale",
					"quaternion",
					"tzurah",
					"chomer",
					"model"
				])
			//	console.log(opts.empty,opts,this)
				Object.defineProperties(this, {
					pashut: {
						get: () => m
					}
				})
				
				
				
				
				var model = opts["model"]
				var m = pawsh || "not"
				
				this.on("getTziur", cb => 
					typeof(cb) == "function" ?
						cb(opts) : 0
				)
				
				tzurah = opts.material || opts.tzurah
				chomer = opts.geometry || opts.chomer
				var started = false;
				var loadedModel, modelString, olam, alreadyLoaded = false,
					animations = [], mixer, maeesuhz = {}
				this.on("loaded", () => {
					this.tzurah = tzurah
					this.chomer = chomer
					m.coyb = this;
				})
				
				this.on("hissHavoos", (d) => {
					if(animations.length > 0) {
						if(
							mixer
							&& typeof(mixer.update) == "function"
						) {
							mixer.update(d)
						}
					}
				})
				
				this.on("cheedaysh", () => {
					if(!mixer) {
						mixer = new THREE.AnimationMixer(m)
					} else {
						mixer._root = m
					}
					maeesuhz = {}
					if(animations) {
						animations.forEach(a => {
							if(typeof(a.name) == "string") {
								maeesuhz[a.name] = mixer.clipAction(a)
								maeesuhz[a.name].play()
								maeesuhz[a.name].paused = true
							}
						})
					}
				})
				
				this.on("boray", (olam) => {
					this.olam = olam
					if(!started) {
						started = true
						if(pawsh) {
							m = pawsh
						} else
						if(typeof(model) == "string") {
							this.model = model
						} else {
							if(!opts.empty) {
							var geom = new YICHOYLISS.Chomer(
								chomer
							),
								material = new YICHOYLISS.Tzurah(
									tzurah
								)
							
							
							if(geom && material) {
								var geomM = geom.malchus(),
								matM = material.malchus()
								m = new THREE.Mesh(geomM, matM)
							}
							else {
								m = new THREE.Mesh()
							}
							} else {
								
								m = new THREE.Mesh()
								/*console.log("YO!",m,
								new THREE.Mesh());*/
							}
							
							if(opts.color) 
								self.color = opts.color
							this.ayshPeula("loaded", this)
						}
					}
				})
				var cl = null;
				Object.defineProperties(this, {
					modelURL: {
						get: () => modelString
					},
					olam: {
						get: () => olam,
						set: o => olam = o
					},
					animations: {
						get: () => animations
					},
					maeesuhz: {
						get: () => maeesuhz
					},
					mixer: {
						get:() => mixer
					},
					setChayoosToOneTime: {
						get: () => name => {
							var n = maeesuhz[name]
							if(n) {
								n.loop = THREE.LoopOnce
							}
						}
					},
					getChayoos: {
						get: () => name => maeesuhz[name]
					},
					pauseChayoos: {
						get: () => shaym => {
							var act = maeesuhz[shaym]
							if(act) {
								act.paused = true
							}
						}
					},
					chayoosShefuh: {
						get: () => (shaym, nm) => {
							var act = maeesuhz[shaym]
							if(act) {
								if(typeof(nm) == "number") {
									act.timeScale = nm;
								}
							}
						}
					},
					resetChayoos: {
						get: () => shaym => {
							var act = maeesuhz[shaym]
							if(act) {
								act.time = 0;
							}
						}
					},
					zmanShelChayoos: {
						get: () => (shaym, nm) => {
							var act = maeesuhz[shaym]
							if(act) {
								if(typeof(nm) == "number") {
									act.time = nm;
								}
								
							}
						}
					},
					playChayoos: {
						get: () => shaym => {
							var act = maeesuhz[shaym]
							if(act) {
								
								if(act.paused) act.paused = false
								act.play()
							}
						}
					},
					color: {
						get: () => shaym => {
							return cl
						},
						set(v) {
							if(m) {
								m.material.color =
								new YICHOYLISS.Gavvan(v)
							}
						}
					},
					model: {
						get: () => () => {
							console.log("hi")
						},
						set: str => {
							if(typeof(str) == "string") {
								
								modelString = str
								if(THREE.GLTFLoader) {
									var l = new THREE.GLTFLoader()
									l.load(modelString, gltf => {
										var gr;
										animations = gltf.animations
										if(gltf.scenes.length > 1) {
										//	gr = new THREE.Group()
										
											gltf.scenes.forEach(scene => {
												gr=(scene)
											})
											this.ayshPeula("sealayk")
											m = gr
											
										} else if(gltf.scenes.length == 1) {
											this.ayshPeula("sealayk")
											m = gltf.scenes[0]
										}
										if(m) {
											if(!alreadyLoaded) {
												this.ayshPeula("loaded", this)
												
												alreadyLoaded = true
											} else {
												this.ayshPeula("goofChadash")
											}
											
											function addCoyb(lst) {
												if(is(lst, "Array")) {
													lst.forEach(x => {
														x.coyb = self
														if(x.children) {
															addCoyb(x.children)
														}
													})
												}
											}
											if(m.children) {
												addCoyb(m.children)
											}
											
										} else {
											this.ayshPeula("problemLoading")
										}
									})
								}
							}
						}
					}
				})
			}
		},
		Ayin: {
			get: () => function(opts={}) {
				YICHOYLISS
				.Nivra
				.call(this, ...arguments)
				
				this.ayshPeula("loaded", this)
				
			}
		},
		BH: {
			get: function() {
				return function(c) {
					if(!YICHOYLISS.oytzayr) {
						YICHOYLISS.oytzayr = {}
					}
					
					YICHOYLISS.oytzayr[YICHOYLISS.hoyveh] = c
				}
			}
		},
		Oytzerfy: {
			get: function() {
				return function(n) {
					var f = YICHOYLISS.oytzayr[n]
					if(f) {
						//return URL.create
					}
				}
			}
		},
		Dawfeem: {
			get: function() {
				return function(f,cbn) {
					function  g(p, cb) {
						if(!YICHOYLISS.dawfeem[p]) {
							var sc = document.createElement("script")
							sc.src = p + ".js"
							document.head.appendChild(sc)
							YICHOYLISS.hoyveh = p
							sc.onload = () => {
								if(cb) cb(1)
								
								YICHOYLISS.dawfeem[p] = 1;
							}
							sc.onerror = () => {
								if(cb) cb(0)
								delete YICHOYLISS.hoyveh
								YICHOYLISS.dawfeem[p] = 0;
							}
						} else {
							if(cb) cb(1)
						}
					}
					var ind = 0;
					(a => 
						g(a[ind], function oy(s) { 
							++ind < f.length ?
								g(a[ind], oy) 
							: typeof(cbn) == "function" ?
								cbn(1) : 0
							
							
						})
					)(Array
					.from(f))
					
				}
			}
		},
		Tzimtzoom: {
			get: () => function(opts = {}) {
				if(opts.dawfeem) 
					YICHOYLISS.Dawfeem(opts.dawfeem, s => {
						if(s) {
							var oy = opts.olam ||
									opts.oyluhm ||
									opts.oylum || 
									opts.world,
									
								w
							if(oy) w = new YICHOYLISS.Olam(oy)
							if(w) {
								w.start()
							}
						}
					})
				
			}
		},
		Olam: {
			get: () => function(opts = {}) {
				YICHOYLISS.Davar.call(this, ...arguments)
				var self = this;
				var renderer, scene, camera, 
					eyein,
					interval,
					originalCan,
					html = opts.html || [],
					htmlElements = [],
					listeners = opts.listeners || {},
					customSize = opts.customSize,
					awlph = opts.choyshech ||
							opts.dark ||
							opts.black
					
					self = this;
				var clock = new THREE.Clock()
				renderer = new THREE.WebGLRenderer({
					alpha:!awlph,
					background:{
						r:1,
						b:0.2,
						g:0.5
					},                                                         
					antialias:true,
					...(
						opts.toyarim || {}
					)
				});
				if(opts.toyarim && opts.toyarim.originalCanvas) {
					originalCan =  opts.toyarim.originalCanvas
					
				}
				scene = new THREE.Scene()
				camera = new THREE.PerspectiveCamera(
					75,
					0,
					0.01,
					10000
				)
				scene.coyb = this
				camera.position.z = 5
				Object.entries(listeners).forEach(x => {
					this.on(x[0], x[1])
				})
				
				html.forEach(x => {
					htmlElements.push(new YICHOYLISS.HtmlNode(x))
				})
				var delta = 0;
				var nivrayim = [],
					updates = [];
				var subLists = {};
				var dafim = {};
				var mouse = {x:0,y:0, clicked:false}
				
				function loop() {
					delta = clock.getDelta()
					renderer.render(scene, camera)
					
					updates.forEach(u => {
						u.ayshPeula("hissHavoos", delta, u);
					})
					self.ayshPeula("hissHavoos", delta, self)
					
				}
				
				setupLights()
				
				function setupLights() {
					var light = new THREE.HemisphereLight(0xffffff, 0x444444)
					light.position.set(0, 20, 0)
					scene.add(light)
					
					var light2 = new THREE.DirectionalLight(0xffffff)
					light2.position.set(0, 20, 10)
					scene.add(light2)
				}
				
				this.on("heesCheelKavZireeka", () => {
					if(renderer) {
						
						de = originalCan || renderer.domElement
						addEventListener("mousemove", e => {
							//console.log(e)
							it=e
							mouse.flatX = (
								
								e.clientX + scrollX 
								- de.offsetLeft
							)
							mouse.flatY = (
								
								e.clientY + scrollY
								- de.offsetTop
								
							)
						
							mouse.x = (
								mouse.flatX /
								de.clientWidth * 2 - 1
							)
							mouse.y = -1 * (
								mouse.flatY /
								de.clientHeight
							) * 2 + 1
							
							//clip space
						});
						
						
					}
				});
				
				addEventListener("mousedown", e => {
					mouse.clicked = true;
					if(!curSelected) {
						self.ayshPeula("kolYotzay")
					}
				});
				
				addEventListener("mouseup", e => {
					mouse.clicked = false;
				});
				var okd = false
				var caster = new THREE.Raycaster();
				var inter = [], lastInter = [],
						justLeft = true;
				this.on("kavZorayk", (info = {}) => {
					var meenim = info.meenim,
						meen = info.meen,
						otherList = info.list,
						mawtzatzaw = (
							typeof(info.mawtzatzaw) == "function" ? 
								info.mawtzatzaw : (() => {})
						),
						ayin = (
							typeof(info.ayin) == "function" ?
								info.ayin : (() => {})
						)
						
					
					
						
					
					if(is(meenim, "Array")) {
						meenim.forEach(x => {
							is(x, "String") &&
								(m => 
									castIt(m)
								)(
									mapIt(self.meen(x))
									
								)
						})
						
					}
					
					is(meen, "String") &&
						castIt(
							mapIt(self.meen(meen))
							
						);
					
					!meen && !meenim &&
						castIt(
							mapIt(nivrayim)
							
						)
						
						
					is(otherList, "Array") &&
						castIt(otherList);
					
					function mapIt(lst) {
						return lst.map(x => (p => {
							function ungroupIt(first) {
								var other = Array.from(first)
								for(let i = 0; i < other.length; i++) {
									
									if(other[i].children) {
										other[i] = single(other[i])
									}
								}
								var groups = findGroupsInChildren(first).map(g => 
									ungroupIt(g.children)
								).flat()
								return [first, groups].flat()
								function findGroupsInChildren(ch) {
									var groups = []
									ch.forEach(c => {
										if(c.type == "Group") {
											groups.push(c)
										}
										if(c.children) {
											var found = findGroupsInChildren(c.children)
											if(found.length > 0)
												groups.push(
													found
												)
										}
									})
									return groups.flat()

								}
								function single(thing) {
									var ar = [],
										ig = false

									for(let i = 0; i < thing.length; i++) {
										ar.push(thing[i])
										if(thing[i].type == "Group") {
											if(!ig) ig = []
											ig.push(i);
										}
									}

									if(ig !== false) {
										ig.forEach(g => {
											ar[g] = ungroupIt(ar[g].children)
											
										})
									}

									return ar.flat();
								}
							}
							return ungroupIt(p.children).flat()
							
						})(x.pashut))
					}
					function castIt(list) {

						list = list.flat()

						
						caster.setFromCamera(mouse, camera);
						inter = caster.intersectObjects(list)
						is(mawtzatzaw, "Function") && 
						inter.length > 0 ? (() => {
							mawtzatzaw(
								inter
							)
							lastInter = inter
							justLeft = false
							
						})()
						: 0
						
						
						inter.length < 1 ? (() => {
							if(!justLeft) {
								ayin(lastInter)
							
								justLeft = true;
							}
						})():0
						
					}
				})
				
				this.on("addMeen", (meenName, meen) => {
					if(
						typeof(meenName) == "string" && 
						!subLists[meenName]
					) {
						subLists[meenName] = [];
					}
					subLists[meenName] && 
						subLists[meenName].push(meen);
				});
				
				var curSelected, maftaychos = {}, prest = {}
				this.on("zeemaynMaftaychos", () => {
					addEventListener("keyup", e => {
						if(maftaychos[e.keyCode]) {
							delete maftaychos[e.keyCode]
						}
						if(prest[e.keyCode]) {
							delete prest[e.keyCode]
						}
						self.ayshPeula("maftayachLimaeeluh", e)
					})
					
					addEventListener("keydown", e => {
						//e.preventDefault()
						maftaychos[e.keyCode] = e
						if(!prest[e.keyCode]) {
							self.ayshPeula("maftayachKoytesh", e)
							prest[e.keyCode] = true
						}
						self.ayshPeula("maftayachLimahtuh", e)
					})
				})
				
				this.on("makeThingsClickable", (potentshul) => {
					
					this.ayshPeula("heesCheelKavZireeka")
					var meen, meenim
					if(is(potentshul, "Array")) 
						meenim = potentshul
					if(is(potentshul, "String")) 
						meen = potentshul
					
					var startedClicked = false,
						startedDown = false, obj = null
					this.on("hissHavoos", () => {
						
						this.ayshPeula("kavZorayk", {
							meen,
							meenim,
							mawtzatzaw(zeeveem) {
								if(
									zeeveem[0].object != obj 
									&& obj !== null
								) {

									obj.coyb.ayshPeula(
										"achbarYotzay", obj
									)
								}
								if(zeeveem[0]) {
									obj = zeeveem[0].object
									var it = (
										zeeveem[0]
										.object
										.coyb
									)
									
									if(it) it
									.ayshPeula("achbarNeechnas", zeeveem[0])
									
									if(mouse.clicked) {
										if(it) it
										.ayshPeula(
											"achbarMatah", zeeveem[0]
										)
										
										if(!startedClicked) {
											if(it) it
											.ayshPeula(
												"achbarLoMatee", zeeveem[0]
											)
											startedClicked = true
										}
										curSelected = it
										startedDown = true;
									} else if(
										startedDown &&
										startedClicked
									) {
										if(it) it
										.ayshPeula(
											"achbarLemaeelaw", zeeveem[0]
										)
										curSelected = it
										startedDown = false;
									}
								}
								
							},
							ayin(zeeveem) {
								
								if(zeeveem[0]) {
									
									var it = (
										zeeveem[0]
										.object
										.coyb
									)
									if(it) it
									.ayshPeula("achbarYotzay", zeeveem[0].object)
								}
								curSelected = null
								
							}
						})
						
						if(!mouse.clicked) {
							startedClicked = false
					//		startedDown = false;
						}
					})
				})
				
				this.hoyseefYesodos([
					"nivrayim",
				//	"dafeem",
					"shaym"
				])
				
				function hoyseefDaf(daf) {
					var shaym = daf.shaym
					var goof = daf.goof
					if(
						(typeof(shaym) == "string")
					) {
						dafim[shaym] = goof
					}
				}
				
				if(typeof opts.dafeem == "object") {
					var k
					for(k in opts.dafeem) {
						hoyseefDaf({
							shaym: k,
							goof: opts.dafeem[k]
						})
					}
				}
				
				oyin = new YICHOYLISS.Ayin({
					pashut: camera
				})
				
				Object.defineProperties(this, {
					meenim: {
						get: () => () => subLists
					},
					meen: {
						get: () => name => {
							return (subLists[name]) || [];
						}
					},
					hoyseefDaf: {
						get: () => hoyseefDaf
					},
					dafeem: {
						get: () => dafim
					},
					achbar: {
						get:() => mouse
					},
					luachHamaftaychos: {
						get: () => maftaychos
					},
					maftayach: {
						get: () => m => maftaychos[m]
					},
					start: {
						get: () => (opts = {}) => {
							var parent = opts.parent || document.body,
								FPS = opts.fps || 60
							parent.appendChild(renderer.domElement)
							renderer.domElement.style.position = "absolute"
							renderer.domElement.style.left = 0
							renderer.domElement.style.top = 0
							renderer.domElement.style.width = "100%"
							renderer.domElement.style.height = "100%"
							renderer.domElement.style.zIndex = -1
							addEventListener("resize", resize)
							resize()
							function resize() {
								
								renderer.setSize(
									parent.clientWidth,
									parent.clientHeight
								)
								
								camera.aspect = (
									renderer.domElement.clientWidth /
									renderer.domElement.clientHeight
								)
								camera.updateProjectionMatrix()
								
								loop()
							}
							if(interval) clearInterval(interval)
							interval = setInterval(loop, 1000 / FPS)
							
							this.ayshPeula("start", this)
						}
					},
					nivrayim: {
						get: () => nivrayim
					},
					maloy: {
						get: () => function(choots) {
							if(typeof(choots) != "object")
								choots = {}
							var k;
							for(k in choots) {
								if(k == "nivrayim") {
									choots[k].forEach(n => {
										var niv;
										try {
											niv = (
												new YICHOYLISS.Nivra(
													n
												)
											)
										} catch(e){}
										if(niv) {
											self.hoyseef(niv)
										} 
										
									})
								}
							}
						}
					},
					hoyseef: {
						get: () => nivra => {
							nivra.on("sealayk", () => {
								var old = scene.children.includes(nivra.pashut)
								var oldn = nivrayim.indexOf(nivra)
								if(oldn > -1) {
									delete nivrayim[oldn]
								}
								if(old) {
									scene.remove(nivra.pashut)	
								}
							})
							nivra.on("goofChadash", () => {
								scene.add(nivra.pashut)
								nivra.ayshPeula("cheedaysh")
							})
							nivra.ayshPeula("boray", this)
							
							nivra.ayshPeula("ready", () => {
								if(nivra.pashut) {
									scene.add(nivra.pashut)
									nivra.ayshPeula("cheedaysh")
									nivrayim.push(nivra)
									
									if(nivra.eventNames.includes(
										"hissHavoos"
									)) updates.push(nivra)
									
									if(nivra.meen) {
										self.ayshPeula(
											"addMeen", 
											nivra.meen, 
											nivra
										);
									}
									
									if(nivra.meenim) {
									
										nivra.meenim.forEach(x => {
											self.ayshPeula(
												"addMeen", 
												x, 
												nivra
											);
										})
									}	
								}
							})
						}
					},
					interval: {
						get: () => interval
					},
					html: {
						get: () => html
					},
					ayin: {
						get: () => oyin
					},
					original: {
						get: () => ({
							renderer,
							scene,
							camera
						})
					},
					domCanvas: {
						get: () => 
							(originalCan || renderer.domElement)
					}
				})
			}
		}
	});
})()
function YICHOYLISS() {
	
}

function addFunctionsAsArrayToObject(fobj1, fobj2) {
	var obj1 = {},
		obj2 = {}, k, j;
	//one at a time
	if(
		typeof(fobj1) == "object" && 
		typeof(fobj2) == "object"
	) {
		for(k in fobj1) {
			doIt(obj1, k, fobj1[k])
		}
		
		for(k in fobj2) {
			doIt(obj2, k, fobj2[k])
		}
		
		for(k in obj1) {
			if(!obj2[k]) obj2[k] = [];
			obj1[k].forEach(x => {
				obj2[k].push(x)
			})

		}
		
		function doIt(obj, k, it) {
			(
				typeof(it) == "function" ?
					(obj[k] = [it])
				: typeof(it) == "object" ?
					(obj[k] = []) &&
					(Array.apply(0, it).forEach(x => (
						typeof(x) == "function" ?
							obj[k].push(x) : 0
					))) : 0
			)
		}
		return obj2;
	}
	
}

function addFunctionsAsArrayToObjecta(fobj1, fobj2) {
	var obj1 = {},
		obj2 = {}, k;
	
	for(k in fobj1) {
		obj1[k] = fobj1[k]
	}
	for(k in fobj2) {
		obj2[k] = fobj2[k]
	}
	
	if(
		typeof(obj1) == "object" &&
		typeof(obj2) == "object"
	) {
		
		for(k in obj1) {
			if(
				typeof obj1[
					k
				] == "function"
			) {
				obj1[k] = [
					obj1[k]
				]
			}
			for(j in obj2) {
				if(k == j) {
					if(
						typeof obj2[
							j
						] == "function"
					) {
						obj2[j] = [
							obj2[j]
						];
						
					}
					
					
					
					if(
						obj1[k]
						.constructor
						.name == "Array" &&
						
						obj2[j]
						.constructor
						.name == "Array"
					) {
						obj1[k].forEach(x => {
							obj2[j].push(x);
						});
					}
				} else {
					if(is(obj1[k],"Array")) {
						obj2[k] = [];
						obj1[k].forEach(x => {
							obj2[k].push(x);
						});
					}
				}
			}
		}
	}
	return obj2;
}
function objEq(obj1, obj2) {
	var t = true, k, j;
	if(
		(typeof(obj1) == "object") &&
		(typeof(obj2) == "object")
	) {
		
		for(k in obj1) {
			if(
				!Object.keys(obj2).includes(k) ||
				obj2[k] !== obj1[k]
			) t = false
		}
		
		for(j in obj2) {
			if(
				!Object.keys(obj1).includes(j) ||
				obj1[j] !== obj2[j]
			) t = false
		}
		/*for(j in obj2) {
			if(k !== j) t = false
			else if(obj1[k] !== obj2[j]) t = false
		}*/
	}
	
	return t
}

function is(it, that) {
	return (
		(it === that) ||
		(
			typeof(it) !== "undefined" &&
			typeof(that) !== "undefined" &&
			(
				(
					typeof(that) == "string" &&
					it.constructor.name == that
				) || 
				(
					typeof(that) == "function" &&
					it.constructor == that
				)
			)
		)
	)
}

YICHOYLISS.dawfeem = {}