! function(e, t) {
    "object" == typeof exports && "undefined" != typeof module ? t(exports, require("@fullcalendar/core")) : "function" == typeof define && define.amd ? define(["exports", "@fullcalendar/core"], t) : t((e = e || self).FullCalendarDayGrid = {}, e.FullCalendar)
}(this, function(e, t) {
    "use strict";
    var r = function(e, t) {
        return (r = Object.setPrototypeOf || {
                __proto__: []
            }
            instanceof Array && function(e, t) {
                e.__proto__ = t
            } || function(e, t) {
                for (var r in t) t.hasOwnProperty(r) && (e[r] = t[r])
            })(e, t)
    };

    function n(e, t) {
        function n() {
            this.constructor = e
        }
        r(e, t), e.prototype = null === t ? Object.create(t) : (n.prototype = t.prototype, new n)
    }
    var i = function() {
            return (i = Object.assign || function(e) {
                for (var t, r = 1, n = arguments.length; r < n; r++)
                    for (var i in t = arguments[r]) Object.prototype.hasOwnProperty.call(t, i) && (e[i] = t[i]);
                return e
            }).apply(this, arguments)
        },
        o = function(e) {
            function r() {
                return null !== e && e.apply(this, arguments) || this
            }
            return n(r, e), r.prototype.buildRenderRange = function(r, n, i) {
                var o, s = this.dateEnv,
                    l = e.prototype.buildRenderRange.call(this, r, n, i),
                    a = l.start,
                    d = l.end;
                if (/^(year|month)$/.test(n) && (a = s.startOfWeek(a), (o = s.startOfWeek(d)).valueOf() !== d.valueOf() && (d = t.addWeeks(o, 1))), this.options.monthMode && this.options.fixedWeekCount) {
                    var c = Math.ceil(t.diffWeeks(a, d));
                    d = t.addWeeks(d, 6 - c)
                }
                return {
                    start: a,
                    end: d
                }
            }, r
        }(t.DateProfileGenerator),
        s = function() {
            function e(e) {
                var t = this;
                this.isHidden = !0, this.margin = 10, this.documentMousedown = function(e) {
                    t.el && !t.el.contains(e.target) && t.hide()
                }, this.options = e
            }
            return e.prototype.show = function() {
                this.isHidden && (this.el || this.render(), this.el.style.display = "", this.position(), this.isHidden = !1, this.trigger("show"))
            }, e.prototype.hide = function() {
                this.isHidden || (this.el.style.display = "none", this.isHidden = !0, this.trigger("hide"))
            }, e.prototype.render = function() {
                var e = this,
                    r = this.options,
                    n = this.el = t.createElement("div", {
                        className: "fc-popover " + (r.className || ""),
                        style: {
                            top: "0",
                            left: "0"
                        }
                    });
                "function" == typeof r.content && r.content(n), r.parentEl.appendChild(n), t.listenBySelector(n, "click", ".fc-close", function(t) {
                    e.hide()
                }), r.autoHide && document.addEventListener("mousedown", this.documentMousedown)
            }, e.prototype.destroy = function() {
                this.hide(), this.el && (t.removeElement(this.el), this.el = null), document.removeEventListener("mousedown", this.documentMousedown)
            }, e.prototype.position = function() {
                var e, r, n = this.options,
                    i = this.el,
                    o = i.getBoundingClientRect(),
                    s = t.computeRect(i.offsetParent),
                    l = t.computeClippingRect(n.parentEl);
                e = n.top || 0, r = void 0 !== n.left ? n.left : void 0 !== n.right ? n.right - o.width : 0, e = Math.min(e, l.bottom - o.height - this.margin), e = Math.max(e, l.top + this.margin), r = Math.min(r, l.right - o.width - this.margin), r = Math.max(r, l.left + this.margin), t.applyStyle(i, {
                    top: e - s.top,
                    left: r - s.left
                })
            }, e.prototype.trigger = function(e) {
                this.options[e] && this.options[e].apply(this, Array.prototype.slice.call(arguments, 1))
            }, e
        }(),
        l = function(e) {
            function r() {
                return null !== e && e.apply(this, arguments) || this
            }
            return n(r, e), r.prototype.renderSegHtml = function(e, r) {
                var n, i, o = this.context,
                    s = o.view,
                    l = o.options,
                    a = e.eventRange,
                    d = a.def,
                    c = a.ui,
                    h = d.allDay,
                    p = s.computeEventDraggable(d, c),
                    u = h && e.isStart && s.computeEventStartResizable(d, c),
                    f = h && e.isEnd && s.computeEventEndResizable(d, c),
                    g = this.getSegClasses(e, p, u || f, r),
                    m = t.cssToStr(this.getSkinCss(c)),
                    y = "";
                return g.unshift("fc-day-grid-event", "fc-h-event"), e.isStart && (n = this.getTimeText(a)) && (y = '<span class="fc-time">' + t.htmlEscape(n) + "</span>"), i = '<span class="fc-title">' + (t.htmlEscape(d.title || "") || "&nbsp;") + "</span>", '<a class="' + g.join(" ") + '"' + (d.url ? ' href="' + t.htmlEscape(d.url) + '"' : "") + (m ? ' style="' + m + '"' : "") + '><div class="fc-content">' + ("rtl" === l.dir ? i + " " + y : y + " " + i) + "</div>" + (u ? '<div class="fc-resizer fc-start-resizer"></div>' : "") + (f ? '<div class="fc-resizer fc-end-resizer"></div>' : "") + "</a>"
            }, r.prototype.computeEventTimeFormat = function() {
                return {
                    hour: "numeric",
                    minute: "2-digit",
                    omitZeroMinute: !0,
                    meridiem: "narrow"
                }
            }, r.prototype.computeDisplayEventEnd = function() {
                return !1
            }, r
        }(t.FgEventRenderer),
        a = function(e) {
            function r(t) {
                var r = e.call(this, t.context) || this;
                return r.dayGrid = t, r
            }
            return n(r, e), r.prototype.attachSegs = function(e, t) {
                var r = this.rowStructs = this.renderSegRows(e);
                this.dayGrid.rowEls.forEach(function(e, t) {
                    e.querySelector(".fc-content-skeleton > table").appendChild(r[t].tbodyEl)
                }), t || this.dayGrid.removeSegPopover()
            }, r.prototype.detachSegs = function() {
                for (var e, r = this.rowStructs || []; e = r.pop();) t.removeElement(e.tbodyEl);
                this.rowStructs = null
            }, r.prototype.renderSegRows = function(e) {
                var t, r, n = [];
                for (t = this.groupSegRows(e), r = 0; r < t.length; r++) n.push(this.renderSegRow(r, t[r]));
                return n
            }, r.prototype.renderSegRow = function(e, r) {
                var n, i, o, s, l, a, d, c = this.dayGrid,
                    h = c.colCnt,
                    p = c.isRtl,
                    u = this.buildSegLevels(r),
                    f = Math.max(1, u.length),
                    g = document.createElement("tbody"),
                    m = [],
                    y = [],
                    v = [];

                function b(e) {
                    for (; o < e;)(d = (v[n - 1] || [])[o]) ? d.rowSpan = (d.rowSpan || 1) + 1 : (d = document.createElement("td"), s.appendChild(d)), y[n][o] = d, v[n][o] = d, o++
                }
                for (n = 0; n < f; n++) {
                    if (i = u[n], o = 0, s = document.createElement("tr"), m.push([]), y.push([]), v.push([]), i)
                        for (l = 0; l < i.length; l++) {
                            a = i[l];
                            var w = p ? h - 1 - a.lastCol : a.firstCol,
                                S = p ? h - 1 - a.firstCol : a.lastCol;
                            for (b(w), d = t.createElement("td", {
                                    className: "fc-event-container"
                                }, a.el), w !== S ? d.colSpan = S - w + 1 : v[n][o] = d; o <= S;) y[n][o] = d, m[n][o] = a, o++;
                            s.appendChild(d)
                        }
                    b(h);
                    var C = c.renderProps.renderIntroHtml();
                    C && (c.isRtl ? t.appendToElement(s, C) : t.prependToElement(s, C)), g.appendChild(s)
                }
                return {
                    row: e,
                    tbodyEl: g,
                    cellMatrix: y,
                    segMatrix: m,
                    segLevels: u,
                    segs: r
                }
            }, r.prototype.buildSegLevels = function(e) {
                var t, r, n, i = this.dayGrid,
                    o = i.isRtl,
                    s = i.colCnt,
                    l = [];
                for (e = this.sortEventSegs(e), t = 0; t < e.length; t++) {
                    for (r = e[t], n = 0; n < l.length && d(r, l[n]); n++);
                    r.level = n, r.leftCol = o ? s - 1 - r.lastCol : r.firstCol, r.rightCol = o ? s - 1 - r.firstCol : r.lastCol, (l[n] || (l[n] = [])).push(r)
                }
                for (n = 0; n < l.length; n++) l[n].sort(c);
                return l
            }, r.prototype.groupSegRows = function(e) {
                var t, r = [];
                for (t = 0; t < this.dayGrid.rowCnt; t++) r.push([]);
                for (t = 0; t < e.length; t++) r[e[t].row].push(e[t]);
                return r
            }, r.prototype.computeDisplayEventEnd = function() {
                return 1 === this.dayGrid.colCnt
            }, r
        }(l);

    function d(e, t) {
        var r, n;
        for (r = 0; r < t.length; r++)
            if ((n = t[r]).firstCol <= e.lastCol && n.lastCol >= e.firstCol) return !0;
        return !1
    }

    function c(e, t) {
        return e.leftCol - t.leftCol
    }
    var h = function(e) {
            function r() {
                return null !== e && e.apply(this, arguments) || this
            }
            return n(r, e), r.prototype.attachSegs = function(e, r) {
                var n = r.sourceSeg,
                    i = this.rowStructs = this.renderSegRows(e);
                this.dayGrid.rowEls.forEach(function(e, r) {
                    var o, s, l = t.htmlToElement('<div class="fc-mirror-skeleton"><table></table></div>');
                    n && n.row === r ? o = n.el : (o = e.querySelector(".fc-content-skeleton tbody")) || (o = e.querySelector(".fc-content-skeleton table")), s = o.getBoundingClientRect().top - e.getBoundingClientRect().top, l.style.top = s + "px", l.querySelector("table").appendChild(i[r].tbodyEl), e.appendChild(l)
                })
            }, r
        }(a),
        p = function(e) {
            function r(t) {
                var r = e.call(this, t.context) || this;
                return r.fillSegTag = "td", r.dayGrid = t, r
            }
            return n(r, e), r.prototype.renderSegs = function(t, r) {
                "bgEvent" === t && (r = r.filter(function(e) {
                    return e.eventRange.def.allDay
                })), e.prototype.renderSegs.call(this, t, r)
            }, r.prototype.attachSegs = function(e, t) {
                var r, n, i, o = [];
                for (r = 0; r < t.length; r++) n = t[r], i = this.renderFillRow(e, n), this.dayGrid.rowEls[n.row].appendChild(i), o.push(i);
                return o
            }, r.prototype.renderFillRow = function(e, r) {
                var n, i, o, s = this.dayGrid,
                    l = s.colCnt,
                    a = s.isRtl,
                    d = a ? l - 1 - r.lastCol : r.firstCol,
                    c = (a ? l - 1 - r.firstCol : r.lastCol) + 1;
                n = "businessHours" === e ? "bgevent" : e.toLowerCase(), o = (i = t.htmlToElement('<div class="fc-' + n + '-skeleton"><table><tr></tr></table></div>')).getElementsByTagName("tr")[0], d > 0 && t.appendToElement(o, new Array(d + 1).join('<td style="pointer-events:none"></td>')), r.el.colSpan = c - d, o.appendChild(r.el), c < l && t.appendToElement(o, new Array(l - c + 1).join('<td style="pointer-events:none"></td>'));
                var h = s.renderProps.renderIntroHtml();
                return h && (s.isRtl ? t.appendToElement(o, h) : t.prependToElement(o, h)), i
            }, r
        }(t.FillRenderer),
        u = function(e) {
            function r(r, n) {
                var i = e.call(this, r, n) || this,
                    o = i.eventRenderer = new f(i),
                    s = i.renderFrame = t.memoizeRendering(i._renderFrame);
                return i.renderFgEvents = t.memoizeRendering(o.renderSegs.bind(o), o.unrender.bind(o), [s]), i.renderEventSelection = t.memoizeRendering(o.selectByInstanceId.bind(o), o.unselectByInstanceId.bind(o), [i.renderFgEvents]), i.renderEventDrag = t.memoizeRendering(o.hideByHash.bind(o), o.showByHash.bind(o), [s]), i.renderEventResize = t.memoizeRendering(o.hideByHash.bind(o), o.showByHash.bind(o), [s]), r.calendar.registerInteractiveComponent(i, {
                    el: i.el,
                    useEventCenter: !1
                }), i
            }
            return n(r, e), r.prototype.render = function(e) {
                this.renderFrame(e.date), this.renderFgEvents(e.fgSegs), this.renderEventSelection(e.eventSelection), this.renderEventDrag(e.eventDragInstances), this.renderEventResize(e.eventResizeInstances)
            }, r.prototype.destroy = function() {
                e.prototype.destroy.call(this), this.renderFrame.unrender(), this.calendar.unregisterInteractiveComponent(this)
            }, r.prototype._renderFrame = function(e) {
                var r = this.theme,
                    n = this.dateEnv.format(e, t.createFormatter(this.opt("dayPopoverFormat")));
                this.el.innerHTML = '<div class="fc-header ' + r.getClass("popoverHeader") + '"><span class="fc-title">' + t.htmlEscape(n) + '</span><span class="fc-close ' + r.getIconClass("close") + '"></span></div><div class="fc-body ' + r.getClass("popoverContent") + '"><div class="fc-event-container"></div></div>', this.segContainerEl = this.el.querySelector(".fc-event-container")
            }, r.prototype.queryHit = function(e, r, n, i) {
                var o = this.props.date;
                if (e < n && r < i) return {
                    component: this,
                    dateSpan: {
                        allDay: !0,
                        range: {
                            start: o,
                            end: t.addDays(o, 1)
                        }
                    },
                    dayEl: this.el,
                    rect: {
                        left: 0,
                        top: 0,
                        right: n,
                        bottom: i
                    },
                    layer: 1
                }
            }, r
        }(t.DateComponent),
        f = function(e) {
            function r(t) {
                var r = e.call(this, t.context) || this;
                return r.dayTile = t, r
            }
            return n(r, e), r.prototype.attachSegs = function(e) {
                for (var t = 0, r = e; t < r.length; t++) {
                    var n = r[t];
                    this.dayTile.segContainerEl.appendChild(n.el)
                }
            }, r.prototype.detachSegs = function(e) {
                for (var r = 0, n = e; r < n.length; r++) {
                    var i = n[r];
                    t.removeElement(i.el)
                }
            }, r
        }(l),
        g = function() {
            function e(e) {
                this.context = e
            }
            return e.prototype.renderHtml = function(e) {
                var t = [];
                e.renderIntroHtml && t.push(e.renderIntroHtml());
                for (var r = 0, n = e.cells; r < n.length; r++) {
                    var i = n[r];
                    t.push(m(i.date, e.dateProfile, this.context, i.htmlAttrs))
                }
                return e.cells.length || t.push('<td class="fc-day ' + this.context.theme.getClass("widgetContent") + '"></td>'), "rtl" === this.context.options.dir && t.reverse(), "<tr>" + t.join("") + "</tr>"
            }, e
        }();

    function m(e, r, n, i) {
        var o = n.dateEnv,
            s = n.theme,
            l = t.rangeContainsMarker(r.activeRange, e),
            a = t.getDayClasses(e, r, n);
        return a.unshift("fc-day", s.getClass("widgetContent")), '<td class="' + a.join(" ") + '"' + (l ? ' data-date="' + o.formatIso(e, {
            omitTime: !0
        }) + '"' : "") + (i ? " " + i : "") + "></td>"
    }
    var y = t.createFormatter({
            day: "numeric"
        }),
        v = t.createFormatter({
            week: "numeric"
        }),
        b = function(e) {
            function r(r, n, i) {
                var o = e.call(this, r, n) || this;
                o.bottomCoordPadding = 0, o.isCellSizesDirty = !1;
                var s = o.eventRenderer = new a(o),
                    l = o.fillRenderer = new p(o);
                o.mirrorRenderer = new h(o);
                var d = o.renderCells = t.memoizeRendering(o._renderCells, o._unrenderCells);
                return o.renderBusinessHours = t.memoizeRendering(l.renderSegs.bind(l, "businessHours"), l.unrender.bind(l, "businessHours"), [d]), o.renderDateSelection = t.memoizeRendering(l.renderSegs.bind(l, "highlight"), l.unrender.bind(l, "highlight"), [d]), o.renderBgEvents = t.memoizeRendering(l.renderSegs.bind(l, "bgEvent"), l.unrender.bind(l, "bgEvent"), [d]), o.renderFgEvents = t.memoizeRendering(s.renderSegs.bind(s), s.unrender.bind(s), [d]), o.renderEventSelection = t.memoizeRendering(s.selectByInstanceId.bind(s), s.unselectByInstanceId.bind(s), [o.renderFgEvents]), o.renderEventDrag = t.memoizeRendering(o._renderEventDrag, o._unrenderEventDrag, [d]), o.renderEventResize = t.memoizeRendering(o._renderEventResize, o._unrenderEventResize, [d]), o.renderProps = i, o
            }
            return n(r, e), r.prototype.render = function(e) {
                var t = e.cells;
                this.rowCnt = t.length, this.colCnt = t[0].length, this.renderCells(t, e.isRigid), this.renderBusinessHours(e.businessHourSegs), this.renderDateSelection(e.dateSelectionSegs), this.renderBgEvents(e.bgEventSegs), this.renderFgEvents(e.fgEventSegs), this.renderEventSelection(e.eventSelection), this.renderEventDrag(e.eventDrag), this.renderEventResize(e.eventResize), this.segPopoverTile && this.updateSegPopoverTile()
            }, r.prototype.destroy = function() {
                e.prototype.destroy.call(this), this.renderCells.unrender()
            }, r.prototype.getCellRange = function(e, r) {
                var n = this.props.cells[e][r].date;
                return {
                    start: n,
                    end: t.addDays(n, 1)
                }
            }, r.prototype.updateSegPopoverTile = function(e, t) {
                var r = this.props;
                this.segPopoverTile.receiveProps({
                    date: e || this.segPopoverTile.props.date,
                    fgSegs: t || this.segPopoverTile.props.fgSegs,
                    eventSelection: r.eventSelection,
                    eventDragInstances: r.eventDrag ? r.eventDrag.affectedInstances : null,
                    eventResizeInstances: r.eventResize ? r.eventResize.affectedInstances : null
                })
            }, r.prototype._renderCells = function(e, r) {
                var n, i, o = this.view,
                    s = this.dateEnv,
                    l = this.rowCnt,
                    a = this.colCnt,
                    d = "";
                for (n = 0; n < l; n++) d += this.renderDayRowHtml(n, r);
                for (this.el.innerHTML = d, this.rowEls = t.findElements(this.el, ".fc-row"), this.cellEls = t.findElements(this.el, ".fc-day, .fc-disabled-day"), this.isRtl && this.cellEls.reverse(), this.rowPositions = new t.PositionCache(this.el, this.rowEls, !1, !0), this.colPositions = new t.PositionCache(this.el, this.cellEls.slice(0, a), !0, !1), n = 0; n < l; n++)
                    for (i = 0; i < a; i++) this.publiclyTrigger("dayRender", [{
                        date: s.toDate(e[n][i].date),
                        el: this.getCellEl(n, i),
                        view: o
                    }]);
                this.isCellSizesDirty = !0
            }, r.prototype._unrenderCells = function() {
                this.removeSegPopover()
            }, r.prototype.renderDayRowHtml = function(e, t) {
                var r = this.theme,
                    n = ["fc-row", "fc-week", r.getClass("dayRow")];
                t && n.push("fc-rigid");
                var i = new g(this.context);
                return '<div class="' + n.join(" ") + '"><div class="fc-bg"><table class="' + r.getClass("tableGrid") + '">' + i.renderHtml({
                    cells: this.props.cells[e],
                    dateProfile: this.props.dateProfile,
                    renderIntroHtml: this.renderProps.renderBgIntroHtml
                }) + '</table></div><div class="fc-content-skeleton"><table>' + (this.getIsNumbersVisible() ? "<thead>" + this.renderNumberTrHtml(e) + "</thead>" : "") + "</table></div></div>"
            }, r.prototype.getIsNumbersVisible = function() {
                return this.getIsDayNumbersVisible() || this.renderProps.cellWeekNumbersVisible || this.renderProps.colWeekNumbersVisible
            }, r.prototype.getIsDayNumbersVisible = function() {
                return this.rowCnt > 1
            }, r.prototype.renderNumberTrHtml = function(e) {
                var t = this.renderProps.renderNumberIntroHtml(e, this);
                return "<tr>" + (this.isRtl ? "" : t) + this.renderNumberCellsHtml(e) + (this.isRtl ? t : "") + "</tr>"
            }, r.prototype.renderNumberCellsHtml = function(e) {
                var t, r, n = [];
                for (t = 0; t < this.colCnt; t++) r = this.props.cells[e][t].date, n.push(this.renderNumberCellHtml(r));
                return this.isRtl && n.reverse(), n.join("")
            }, r.prototype.renderNumberCellHtml = function(e) {
                var r, n, i = this.view,
                    o = this.dateEnv,
                    s = "",
                    l = t.rangeContainsMarker(this.props.dateProfile.activeRange, e),
                    a = this.getIsDayNumbersVisible() && l;
                return a || this.renderProps.cellWeekNumbersVisible ? ((r = t.getDayClasses(e, this.props.dateProfile, this.context)).unshift("fc-day-top"), this.renderProps.cellWeekNumbersVisible && (n = o.weekDow), s += '<td class="' + r.join(" ") + '"' + (l ? ' data-date="' + o.formatIso(e, {
                    omitTime: !0
                }) + '"' : "") + ">", this.renderProps.cellWeekNumbersVisible && e.getUTCDay() === n && (s += t.buildGotoAnchorHtml(i, {
                    date: e,
                    type: "week"
                }, {
                    class: "fc-week-number"
                }, o.format(e, v))), a && (s += t.buildGotoAnchorHtml(i, e, {
                    class: "fc-day-number"
                }, o.format(e, y))), s += "</td>") : "<td></td>"
            }, r.prototype.updateSize = function(e) {
                var t = this.fillRenderer,
                    r = this.eventRenderer,
                    n = this.mirrorRenderer;
                (e || this.isCellSizesDirty || this.view.calendar.isEventsUpdated) && (this.buildPositionCaches(), this.isCellSizesDirty = !1), t.computeSizes(e), r.computeSizes(e), n.computeSizes(e), t.assignSizes(e), r.assignSizes(e), n.assignSizes(e)
            }, r.prototype.buildPositionCaches = function() {
                this.buildColPositions(), this.buildRowPositions()
            }, r.prototype.buildColPositions = function() {
                this.colPositions.build()
            }, r.prototype.buildRowPositions = function() {
                this.rowPositions.build(), this.rowPositions.bottoms[this.rowCnt - 1] += this.bottomCoordPadding
            }, r.prototype.positionToHit = function(e, t) {
                var r = this.colPositions,
                    n = this.rowPositions,
                    i = r.leftToIndex(e),
                    o = n.topToIndex(t);
                if (null != o && null != i) return {
                    row: o,
                    col: i,
                    dateSpan: {
                        range: this.getCellRange(o, i),
                        allDay: !0
                    },
                    dayEl: this.getCellEl(o, i),
                    relativeRect: {
                        left: r.lefts[i],
                        right: r.rights[i],
                        top: n.tops[o],
                        bottom: n.bottoms[o]
                    }
                }
            }, r.prototype.getCellEl = function(e, t) {
                return this.cellEls[e * this.colCnt + t]
            }, r.prototype._renderEventDrag = function(e) {
                e && (this.eventRenderer.hideByHash(e.affectedInstances), this.fillRenderer.renderSegs("highlight", e.segs))
            }, r.prototype._unrenderEventDrag = function(e) {
                e && (this.eventRenderer.showByHash(e.affectedInstances), this.fillRenderer.unrender("highlight"))
            }, r.prototype._renderEventResize = function(e) {
                e && (this.eventRenderer.hideByHash(e.affectedInstances), this.fillRenderer.renderSegs("highlight", e.segs), this.mirrorRenderer.renderSegs(e.segs, {
                    isResizing: !0,
                    sourceSeg: e.sourceSeg
                }))
            }, r.prototype._unrenderEventResize = function(e) {
                e && (this.eventRenderer.showByHash(e.affectedInstances), this.fillRenderer.unrender("highlight"), this.mirrorRenderer.unrender(e.segs, {
                    isResizing: !0,
                    sourceSeg: e.sourceSeg
                }))
            }, r.prototype.removeSegPopover = function() {
                this.segPopover && this.segPopover.hide()
            }, r.prototype.limitRows = function(e) {
                var t, r, n = this.eventRenderer.rowStructs || [];
                for (t = 0; t < n.length; t++) this.unlimitRow(t), !1 !== (r = !!e && ("number" == typeof e ? e : this.computeRowLevelLimit(t))) && this.limitRow(t, r)
            }, r.prototype.computeRowLevelLimit = function(e) {
                var r, n, i = this.rowEls[e].getBoundingClientRect().bottom,
                    o = t.findChildren(this.eventRenderer.rowStructs[e].tbodyEl);
                for (r = 0; r < o.length; r++)
                    if ((n = o[r]).classList.remove("fc-limited"), n.getBoundingClientRect().bottom > i) return r;
                return !1
            }, r.prototype.limitRow = function(e, r) {
                var n, i, o, s, l, a, d, c, h, p, u, f, g, m, y, v = this,
                    b = this.colCnt,
                    w = this.isRtl,
                    S = this.eventRenderer.rowStructs[e],
                    C = [],
                    E = 0,
                    R = function(n) {
                        for (; E < n;)(a = v.getCellSegs(e, E, r)).length && (h = i[r - 1][E], y = v.renderMoreLink(e, E, a), m = t.createElement("div", null, y), h.appendChild(m), C.push(m)), E++
                    };
                if (r && r < S.segLevels.length) {
                    for (n = S.segLevels[r - 1], i = S.cellMatrix, (o = t.findChildren(S.tbodyEl).slice(r)).forEach(function(e) {
                            e.classList.add("fc-limited")
                        }), s = 0; s < n.length; s++) {
                        l = n[s];
                        var H = w ? b - 1 - l.lastCol : l.firstCol,
                            D = w ? b - 1 - l.firstCol : l.lastCol;
                        for (R(H), c = [], d = 0; E <= D;) a = this.getCellSegs(e, E, r), c.push(a), d += a.length, E++;
                        if (d) {
                            for (p = (h = i[r - 1][H]).rowSpan || 1, u = [], f = 0; f < c.length; f++) g = t.createElement("td", {
                                className: "fc-more-cell",
                                rowSpan: p
                            }), a = c[f], y = this.renderMoreLink(e, H + f, [l].concat(a)), m = t.createElement("div", null, y), g.appendChild(m), u.push(g), C.push(g);
                            h.classList.add("fc-limited"), t.insertAfterElement(h, u), o.push(h)
                        }
                    }
                    R(this.colCnt), S.moreEls = C, S.limitedEls = o
                }
            }, r.prototype.unlimitRow = function(e) {
                var r = this.eventRenderer.rowStructs[e];
                r.moreEls && (r.moreEls.forEach(t.removeElement), r.moreEls = null), r.limitedEls && (r.limitedEls.forEach(function(e) {
                    e.classList.remove("fc-limited")
                }), r.limitedEls = null)
            }, r.prototype.renderMoreLink = function(e, r, n) {
                var i = this,
                    o = this.view,
                    s = this.dateEnv,
                    l = t.createElement("a", {
                        className: "fc-more"
                    });
                return l.innerText = this.getMoreLinkText(n.length), l.addEventListener("click", function(t) {
                    var l = i.opt("eventLimitClick"),
                        a = i.isRtl ? i.colCnt - r - 1 : r,
                        d = i.props.cells[e][a].date,
                        c = t.currentTarget,
                        h = i.getCellEl(e, r),
                        p = i.getCellSegs(e, r),
                        u = i.resliceDaySegs(p, d),
                        f = i.resliceDaySegs(n, d);
                    "function" == typeof l && (l = i.publiclyTrigger("eventLimitClick", [{
                        date: s.toDate(d),
                        allDay: !0,
                        dayEl: h,
                        moreEl: c,
                        segs: u,
                        hiddenSegs: f,
                        jsEvent: t,
                        view: o
                    }])), "popover" === l ? i.showSegPopover(e, r, c, u) : "string" == typeof l && o.calendar.zoomTo(d, l)
                }), l
            }, r.prototype.showSegPopover = function(e, r, n, i) {
                var o, l, a = this,
                    d = this.calendar,
                    c = this.view,
                    h = this.theme,
                    p = this.isRtl ? this.colCnt - r - 1 : r,
                    f = n.parentNode;
                o = 1 === this.rowCnt ? c.el : this.rowEls[e], l = {
                    className: "fc-more-popover " + h.getClass("popover"),
                    parentEl: c.el,
                    top: t.computeRect(o).top,
                    autoHide: !0,
                    content: function(t) {
                        a.segPopoverTile = new u(a.context, t), a.updateSegPopoverTile(a.props.cells[e][p].date, i)
                    },
                    hide: function() {
                        a.segPopoverTile.destroy(), a.segPopoverTile = null, a.segPopover.destroy(), a.segPopover = null
                    }
                }, this.isRtl ? l.right = t.computeRect(f).right + 1 : l.left = t.computeRect(f).left - 1, this.segPopover = new s(l), this.segPopover.show(), d.releaseAfterSizingTriggers()
            }, r.prototype.resliceDaySegs = function(e, r) {
                for (var n = r, o = {
                        start: n,
                        end: t.addDays(n, 1)
                    }, s = [], l = 0, a = e; l < a.length; l++) {
                    var d = a[l],
                        c = d.eventRange,
                        h = c.range,
                        p = t.intersectRanges(h, o);
                    p && s.push(i({}, d, {
                        eventRange: {
                            def: c.def,
                            ui: i({}, c.ui, {
                                durationEditable: !1
                            }),
                            instance: c.instance,
                            range: p
                        },
                        isStart: d.isStart && p.start.valueOf() === h.start.valueOf(),
                        isEnd: d.isEnd && p.end.valueOf() === h.end.valueOf()
                    }))
                }
                return s
            }, r.prototype.getMoreLinkText = function(e) {
                var t = this.opt("eventLimitText");
                return "function" == typeof t ? t(e) : "+" + e + " " + t
            }, r.prototype.getCellSegs = function(e, t, r) {
                for (var n, i = this.eventRenderer.rowStructs[e].segMatrix, o = r || 0, s = []; o < i.length;)(n = i[o][t]) && s.push(n), o++;
                return s
            }, r
        }(t.DateComponent),
        w = t.createFormatter({
            week: "numeric"
        }),
        S = function(e) {
            function r(r, n, i, o) {
                var s = e.call(this, r, n, i, o) || this;
                s.renderHeadIntroHtml = function() {
                    var e = s.theme;
                    return s.colWeekNumbersVisible ? '<th class="fc-week-number ' + e.getClass("widgetHeader") + '" ' + s.weekNumberStyleAttr() + "><span>" + t.htmlEscape(s.opt("weekLabel")) + "</span></th>" : ""
                }, s.renderDayGridNumberIntroHtml = function(e, r) {
                    var n = s.dateEnv,
                        i = r.props.cells[e][0].date;
                    return s.colWeekNumbersVisible ? '<td class="fc-week-number" ' + s.weekNumberStyleAttr() + ">" + t.buildGotoAnchorHtml(s, {
                        date: i,
                        type: "week",
                        forceOff: 1 === r.colCnt
                    }, n.format(i, w)) + "</td>" : ""
                }, s.renderDayGridBgIntroHtml = function() {
                    var e = s.theme;
                    return s.colWeekNumbersVisible ? '<td class="fc-week-number ' + e.getClass("widgetContent") + '" ' + s.weekNumberStyleAttr() + "></td>" : ""
                }, s.renderDayGridIntroHtml = function() {
                    return s.colWeekNumbersVisible ? '<td class="fc-week-number" ' + s.weekNumberStyleAttr() + "></td>" : ""
                }, s.el.classList.add("fc-dayGrid-view"), s.el.innerHTML = s.renderSkeletonHtml(), s.scroller = new t.ScrollComponent("hidden", "auto");
                var l = s.scroller.el;
                s.el.querySelector(".fc-body > tr > td").appendChild(l), l.classList.add("fc-day-grid-container");
                var a, d = t.createElement("div", {
                    className: "fc-day-grid"
                });
                return l.appendChild(d), s.opt("weekNumbers") ? s.opt("weekNumbersWithinDays") ? (a = !0, s.colWeekNumbersVisible = !1) : (a = !1, s.colWeekNumbersVisible = !0) : (s.colWeekNumbersVisible = !1, a = !1), s.dayGrid = new b(s.context, d, {
                    renderNumberIntroHtml: s.renderDayGridNumberIntroHtml,
                    renderBgIntroHtml: s.renderDayGridBgIntroHtml,
                    renderIntroHtml: s.renderDayGridIntroHtml,
                    colWeekNumbersVisible: s.colWeekNumbersVisible,
                    cellWeekNumbersVisible: a
                }), s
            }
            return n(r, e), r.prototype.destroy = function() {
                e.prototype.destroy.call(this), this.dayGrid.destroy(), this.scroller.destroy()
            }, r.prototype.renderSkeletonHtml = function() {
                var e = this.theme;
                return '<table class="' + e.getClass("tableGrid") + '">' + (this.opt("columnHeader") ? '<thead class="fc-head"><tr><td class="fc-head-container ' + e.getClass("widgetHeader") + '">&nbsp;</td></tr></thead>' : "") + '<tbody class="fc-body"><tr><td class="' + e.getClass("widgetContent") + '"></td></tr></tbody></table>'
            }, r.prototype.weekNumberStyleAttr = function() {
                return null != this.weekNumberWidth ? 'style="width:' + this.weekNumberWidth + 'px"' : ""
            }, r.prototype.hasRigidRows = function() {
                var e = this.opt("eventLimit");
                return e && "number" != typeof e
            }, r.prototype.updateSize = function(t, r, n) {
                e.prototype.updateSize.call(this, t, r, n), this.dayGrid.updateSize(t)
            }, r.prototype.updateBaseSize = function(e, r, n) {
                var i, o, s = this.dayGrid,
                    l = this.opt("eventLimit"),
                    a = this.header ? this.header.el : null;
                s.rowEls ? (this.colWeekNumbersVisible && (this.weekNumberWidth = t.matchCellWidths(t.findElements(this.el, ".fc-week-number"))), this.scroller.clear(), a && t.uncompensateScroll(a), s.removeSegPopover(), l && "number" == typeof l && s.limitRows(l), i = this.computeScrollerHeight(r), this.setGridHeight(i, n), l && "number" != typeof l && s.limitRows(l), n || (this.scroller.setHeight(i), ((o = this.scroller.getScrollbarWidths()).left || o.right) && (a && t.compensateScroll(a, o), i = this.computeScrollerHeight(r), this.scroller.setHeight(i)), this.scroller.lockOverflow(o))) : n || (i = this.computeScrollerHeight(r), this.scroller.setHeight(i))
            }, r.prototype.computeScrollerHeight = function(e) {
                return e - t.subtractInnerElHeight(this.el, this.scroller.el)
            }, r.prototype.setGridHeight = function(e, r) {
                this.opt("monthMode") ? (r && (e *= this.dayGrid.rowCnt / 6), t.distributeHeight(this.dayGrid.rowEls, e, !r)) : r ? t.undistributeHeight(this.dayGrid.rowEls) : t.distributeHeight(this.dayGrid.rowEls, e, !0)
            }, r.prototype.computeDateScroll = function(e) {
                return {
                    top: 0
                }
            }, r.prototype.queryDateScroll = function() {
                return {
                    top: this.scroller.getScrollTop()
                }
            }, r.prototype.applyDateScroll = function(e) {
                void 0 !== e.top && this.scroller.setScrollTop(e.top)
            }, r
        }(t.View);
    S.prototype.dateProfileGeneratorClass = o;
    var C = function(e) {
            function t(t, r) {
                var n = e.call(this, t, r.el) || this;
                return n.slicer = new E, n.dayGrid = r, t.calendar.registerInteractiveComponent(n, {
                    el: n.dayGrid.el
                }), n
            }
            return n(t, e), t.prototype.destroy = function() {
                e.prototype.destroy.call(this), this.calendar.unregisterInteractiveComponent(this)
            }, t.prototype.render = function(e) {
                var t = this.dayGrid,
                    r = e.dateProfile,
                    n = e.dayTable;
                t.receiveProps(i({}, this.slicer.sliceProps(e, r, e.nextDayThreshold, t, n), {
                    dateProfile: r,
                    cells: n.cells,
                    isRigid: e.isRigid
                }))
            }, t.prototype.buildPositionCaches = function() {
                this.dayGrid.buildPositionCaches()
            }, t.prototype.queryHit = function(e, t) {
                var r = this.dayGrid.positionToHit(e, t);
                if (r) return {
                    component: this.dayGrid,
                    dateSpan: r.dateSpan,
                    dayEl: r.dayEl,
                    rect: {
                        left: r.relativeRect.left,
                        right: r.relativeRect.right,
                        top: r.relativeRect.top,
                        bottom: r.relativeRect.bottom
                    },
                    layer: 0
                }
            }, t
        }(t.DateComponent),
        E = function(e) {
            function t() {
                return null !== e && e.apply(this, arguments) || this
            }
            return n(t, e), t.prototype.sliceRange = function(e, t) {
                return t.sliceRange(e)
            }, t
        }(t.Slicer),
        R = function(e) {
            function r(r, n, i, o) {
                var s = e.call(this, r, n, i, o) || this;
                return s.buildDayTable = t.memoize(H), s.opt("columnHeader") && (s.header = new t.DayHeader(s.context, s.el.querySelector(".fc-head-container"))), s.simpleDayGrid = new C(s.context, s.dayGrid), s
            }
            return n(r, e), r.prototype.destroy = function() {
                e.prototype.destroy.call(this), this.header && this.header.destroy(), this.simpleDayGrid.destroy()
            }, r.prototype.render = function(t) {
                e.prototype.render.call(this, t);
                var r = this.props.dateProfile,
                    n = this.dayTable = this.buildDayTable(r, this.dateProfileGenerator);
                this.header && this.header.receiveProps({
                    dateProfile: r,
                    dates: n.headerDates,
                    datesRepDistinctDays: 1 === n.rowCnt,
                    renderIntroHtml: this.renderHeadIntroHtml
                }), this.simpleDayGrid.receiveProps({
                    dateProfile: r,
                    dayTable: n,
                    businessHours: t.businessHours,
                    dateSelection: t.dateSelection,
                    eventStore: t.eventStore,
                    eventUiBases: t.eventUiBases,
                    eventSelection: t.eventSelection,
                    eventDrag: t.eventDrag,
                    eventResize: t.eventResize,
                    isRigid: this.hasRigidRows(),
                    nextDayThreshold: this.nextDayThreshold
                })
            }, r
        }(S);

    function H(e, r) {
        var n = new t.DaySeries(e.renderRange, r);
        return new t.DayTable(n, /year|month|week/.test(e.currentRangeUnit))
    }
    var D = t.createPlugin({
        defaultView: "dayGridMonth",
        views: {
            dayGrid: R,
            dayGridDay: {
                type: "dayGrid",
                duration: {
                    days: 1
                }
            },
            dayGridWeek: {
                type: "dayGrid",
                duration: {
                    weeks: 1
                }
            },
            dayGridMonth: {
                type: "dayGrid",
                duration: {
                    months: 1
                },
                monthMode: !0,
                fixedWeekCount: !0
            }
        }
    });
    e.AbstractDayGridView = S, e.DayBgRow = g, e.DayGrid = b, e.DayGridSlicer = E, e.DayGridView = R, e.SimpleDayGrid = C, e.buildBasicDayTable = H, e.default = D, Object.defineProperty(e, "__esModule", {
        value: !0
    })
});