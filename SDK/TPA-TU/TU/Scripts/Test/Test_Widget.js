/// <reference path="../JQueryUI/jquery-1.11.1.js" />
/// <reference path="../Portal/Widget.js" />

NavigableMenuDetail = { WidgetOrders: "{ \"A\": \"1\" }" };
homeViewModel = null

test("Test slotManager.sortSlotsByRank", function () {
    slotManager.slots = [{ slotId: 2, widgetId: 2, rank: 2 },
                         { slotId: 1, widgetId: 1, rank: 1 },
                         { slotId: 3, widgetId: 3, rank: 3 },
                         { slotId: 5, widgetId: 5, rank: 5 },
                         { slotId: 4, widgetId: 4, rank: 4 },];

    slotManager.sortSlotsByRank();

    ok(slotManager.slots[0].rank == 1, "Passed!");
    ok(slotManager.slots[1].rank == 2, "Passed!");
    ok(slotManager.slots[2].rank == 3, "Passed!");
    ok(slotManager.slots[3].rank == 4, "Passed!");
    ok(slotManager.slots[4].rank == 5, "Passed!");
});

test("Test slotManager.recalculateRanks", function () {
    slotManager.slots = [{ slotId: 2, widgetId: 2, rank: 12 },
                         { slotId: 1, widgetId: 1, rank: 11 },
                         { slotId: 3, widgetId: 3, rank: 13 },
                         { slotId: 5, widgetId: 5, rank: 15 },
                         { slotId: 4, widgetId: 4, rank: 14 }, ];

    slotManager.recalculateRanks();

    ok(slotManager.slots[0].rank == 1, "Passed!");
    ok(slotManager.slots[1].rank == 2, "Passed!");
    ok(slotManager.slots[2].rank == 3, "Passed!");
    ok(slotManager.slots[3].rank == 4, "Passed!");
    ok(slotManager.slots[4].rank == 5, "Passed!");
});

test("Test slotManager.getSlotById", function () {
    slotManager.slots = [{ slotId: 2, widgetId: 2, rank: 2 },
                         { slotId: 1, widgetId: 1, rank: 1 },
                         { slotId: 3, widgetId: 3, rank: 3 },
                         { slotId: 5, widgetId: 5, rank: 5 },
                         { slotId: 4, widgetId: 4, rank: 4 }, ];

    ok(slotManager.getSlotById(3).slotId == 3, "Passed!");
});

test("Test slotManager.registerSlot", function () {
    slotManager.slots = [{ slotId: 2, widgetId: 2, rank: 2 },
                         { slotId: 1, widgetId: 1, rank: 1 },
                         { slotId: 3, widgetId: 3, rank: 3 },
                         { slotId: 5, widgetId: 5, rank: 5 },
                         { slotId: 4, widgetId: 4, rank: 4 }, ];


    var newSlot = slotManager.registerSlot(6, 6, 6);

    ok(newSlot.slotId == 6, "Passed!");
    ok(slotManager.slots[slotManager.slots.length - 1].widgetId == 6, "Passed!");
    
});

test("Test slotManager.unregisterSlot", function () {
    slotManager.slots = [{ slotId: 2, widgetId: 2, rank: 2 },
                         { slotId: 1, widgetId: 1, rank: 1 },
                         { slotId: 3, widgetId: 3, rank: 3 },
                         { slotId: 5, widgetId: 5, rank: 5 },
                         { slotId: 4, widgetId: 4, rank: 4 }, ];

    ok(slotManager.unregisterSlot(4), "Passed!");
    ok(slotManager.getSlotById(4) == null, "Passed!");
});