//--------------------------------------
//               PowerUI
//
//        For documentation or 
//    if you have any issues, visit
//        powerUI.kulestar.com
//
//    Copyright � 2013 Kulestar Ltd
//          www.kulestar.com
//--------------------------------------

using System;
using Dom;
using PowerUI;
using Jint.Native;

namespace Dom {

    /// <summary>
    /// These are the "Global Event Handlers".
    /// </summary>

    public partial class Element {
        public static void generalAdder(Element self, object value, string eventName) {
            /*  var g = eventT.MakeGenericType(eventT.GetType());

              var a = typeof(EventListener<>).MakeGenericType(eventT);
              object listener = Activator.CreateInstance(a, new object[] {
                  new Action<KeyboardEvent>((e) => {

                  })
              });*/
            //    new EventListener<KeyboardEvent>();
            //   (listener as EventListener<KeyboardEvent>);
            self.addEventListener(eventName, new EventListener<Event>((e) => {
                if (value is Func<JsValue, JsValue[], JsValue>) {
                    var func = value as Func<JsValue, JsValue[], JsValue>;

                    func(new JsValue(true),
                        new JsValue[1] {JsValue.FromObject(
                                  (e.document as HtmlDocument).JavascriptEngine.Engine,
                                  e
                              )}
                    );
                }

                if(value is Action<Event> a) {
                    a?.Invoke(e);
                }
            }));
        }

        public object onkeypress {
            get {
                return GetFirstDelegate<Action<KeyboardEvent>>("keypress");
            }
            set {
                generalAdder(this, value, "keypress");
            }
        }
        /// <summary>Called when this element receives a keyup.</summary>
        public object onkeyup {
            get {
                return GetFirstDelegate<Action<KeyboardEvent>>("keyup");
            }
            set {
                generalAdder(this, value, "keyup");
            }
        }

        /// <summary>Called when this element receives a keydown.</summary>
        public object onkeydown {
            get {
                return GetFirstDelegate<Action<KeyboardEvent>>("keydown");
            }
            set {
                generalAdder(this, value, "keydown");
            }
        }

        /// <summary>Called when this element receives a mouseup.</summary>
        public object onmouseup {
            get {
                return GetFirstDelegate<Action<MouseEvent>>("mouseup");
            }
            set {
                generalAdder(this, value, "mouseup");
            }
        }

        /// <summary>Called when this element receives a mouseout.</summary>
        public object onmouseout {
            get {
                return GetFirstDelegate<Action<MouseEvent>>("mouseout");
            }
            set {
                generalAdder(this, value, "mouseout");
            }
        }

        /// <summary>Called when this element receives a mousedown.</summary>
        public object onmousedown {
            get {
                return GetFirstDelegate<Action<MouseEvent>>("mousedown");
            }
            set {
                generalAdder(this, value, "mousedown");
            }
        }

        /// <summary>Called when this element receives a mousemove. Note that it must be focused.</summary>
        public object onmousemove {
            get {
                return GetFirstDelegate<Action<MouseEvent>>("mousemove");
            }
            set {
                generalAdder(this, value, "mousemove");
            }
        }

        /// <summary>Called when this element receives a mouseover.</summary>
        public object onmouseover {
            get {
                return GetFirstDelegate<Action<MouseEvent>>("mouseover");
            }
            set {
                generalAdder(this, value, "mouseover");
            }
        }

        /// <summary>Called when this element receives a scrollwheel event.</summary>
        public object onwheel {
            get {
                return GetFirstDelegate<Action<WheelEvent>>("wheel");
            }
            set {
                generalAdder(this, value, "wheel");
            }
        }

        /// <summary>Called when a form is reset.</summary>
        public object onreset {
            get {
                return GetFirstDelegate<Action<FormEvent>>("reset");
            }
            set {
                generalAdder(this, value, "reset");
            }
        }

        /// <summary>Called when a form is submitted.</summary>
        public object onsubmit {
            get {
                return GetFirstDelegate<Action<FormEvent>>("submit");
            }
            set {
                generalAdder(this, value, "submit");
            }
        }

        /// <summary>Called when this element receives a load event (e.g. iframe).</summary>
        public object onload {
            get {
                return GetFirstDelegate<Action<UIEvent>>("load");
            }
            set {
                generalAdder(this, value, "load");
            }
        }

        /// <summary>Called when this element gets focused.</summary>
        public object onfocus {
            get {
                return GetFirstDelegate<Action<FocusEvent>>("focus");
            }
            set {
                generalAdder(this, value, "focus");
            }
        }

        /// <summary>Called just before this element is focused.</summary>
        public object onfocusin {
            get {
                return GetFirstDelegate<Action<FocusEvent>>("focusin");
            }
            set {
                generalAdder(this, value, "focusin");
            }
        }

        /// <summary>Called just before this element is blurred.</summary>
        public object onfocusout {
            get {
                return GetFirstDelegate<Action<FocusEvent>>("focusout");
            }
            set {
                generalAdder(this, value, "focusout");
            }
        }

        /// <summary>Called when this element is unfocused (blurred).</summary>
        public object onblur {
            get {
                return GetFirstDelegate<Action<FocusEvent>>("blur");
            }
            set {
                generalAdder(this, value, "blur");
            }
        }
        /// <summary>Called when this element receives a full click.</summary>
        public object onclick {
            get {

                return GetFirstDelegate<Action<MouseEvent>>("click");
            }
            set {

                generalAdder(this, value, "click");
            }
        }

        /// <summary>Used by e.g. input, select etc. Called when its value changes.</summary>
        public object onchange {
            get {
                return GetFirstDelegate<Action<Dom.Event>>("change");
            }
            set {
                generalAdder(this, value, "change");
            }
        }

    }

}