using UnityEngine;
using Jint.Native;
using Jint;
using System.Collections.Generic;
using System.Collections;
using System;
using PowerUI;
namespace Achdus {
    public class Olam {
        private List<Nivra> nivraList = new List<Nivra>();
        private int LastNivraID = 0;
        public Olam() : this(JsValue.Null) { }
        public Davar p;
        public Olam(JsValue sefiros) {
            p = new Davar(sefiros);
            HissHaveh();
        }

        void HissHaveh() {
            if (p["nivrayim"] is object[] creations) {
                for(var i = 0; i < creations.Length; i++) {
                    try {
                        BoreiNivra(creations[i]);
                    } catch(Exception e) {
                        Debug.Log(e);
                    }
                }
            }
        }

        public Nivra BoreiNivra(dynamic info) {
            var davar = new Davar(info);
            if (davar != null) {

                var nivra = new Nivra(davar);
                nivra.NivraID = LastNivraID++;
                nivraList.Add(nivra);
                return nivra;
            }
            return null;
        }

        public Nivra FindNivra(Func<JsValue, JsValue[], JsValue> checker) {
            var nivra = nivraList.Find(x => {
                return checker(JsValue.FromObject(UI.document.JavascriptEngine.Engine, this), new JsValue[] {
                        JsValue.FromObject(UI.document.JavascriptEngine.Engine, x)
                     }).AsBoolean();
            });
            return nivra;
        }

        public Nivra FindNivra(Predicate<Nivra> checker) {
            return nivraList.Find(checker);
        }

        public Nivra[] FindAllNivraim(Func<JsValue, JsValue[], JsValue> checker) {
            var nivra = nivraList.FindAll(x => {
                return checker(JsValue.FromObject(UI.document.JavascriptEngine.Engine, this), new JsValue[] {
                        JsValue.FromObject(UI.document.JavascriptEngine.Engine, x)
                     }).AsBoolean();
            }).ToArray();
            return nivra;
        }

        public Nivra[] FindAllNivraim(Predicate<Nivra> checker) {
            return nivraList.FindAll(checker).ToArray();
        }

        public void SaleikNivra(Predicate<Nivra> checker) {
            nivraList.Remove(FindNivra(checker));
        }

        void Update() {

        }

        public override string ToString() {
            return base.ToString();
        }
    }
    
    
}
