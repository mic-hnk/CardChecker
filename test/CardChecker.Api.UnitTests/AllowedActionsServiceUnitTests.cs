namespace CardChecker.Api.UnitTests;

public class AllowedActionsServiceUnitTests
{
    private static AllowedActionsService Sut => new();

    [Theory]
    [MemberData(nameof(CardDetails))]
    public void CheckAllowedActions_ForGivenCardTypeAndStatus_ReturnsExpectedActions(CardDetails card, CardAction[] expectedActions)
    {
        var actual = Sut.CheckAllowedActions(card);

        Assert.Equal(expectedActions, actual);
    }

    public static IEnumerable<object[]> CardDetails =>
    [
        #region PrepaidCards

        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Ordered, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Ordered, false),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Inactive, true),
            new CardAction[] { CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Inactive, false),
            new CardAction[] { CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Active, true),
            new CardAction[] { CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Active, false),
            new CardAction[] { CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Restricted, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Blocked, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Blocked, false),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action8, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Expired, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Prepaid, CardStatus.Closed, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action9 }
        ],

        #endregion

        #region DebitCards

        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Ordered, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Ordered, false),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Inactive, true),
            new CardAction[] { CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Inactive, false),
            new CardAction[] { CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Active, true),
            new CardAction[] { CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Active, false),
            new CardAction[] { CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Restricted, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Blocked, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Blocked, false),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action8, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Expired, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Debit, CardStatus.Closed, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action9 }
        ],

        #endregion

        #region CreditCards

        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Ordered, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Ordered, false),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Inactive, true),
            new CardAction[] { CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Inactive, false),
            new CardAction[] { CardAction.Action2, CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Active, true),
            new CardAction[] { CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Active, false),
            new CardAction[] { CardAction.Action1, CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action7, CardAction.Action8, CardAction.Action9, CardAction.Action10, CardAction.Action11, CardAction.Action12, CardAction.Action13 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Restricted, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Blocked, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action6, CardAction.Action7, CardAction.Action8, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Blocked, false),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action8, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Expired, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 }
        ],
        [
            new CardDetails("CardNumber", CardType.Credit, CardStatus.Closed, true),
            new CardAction[] { CardAction.Action3, CardAction.Action4, CardAction.Action5, CardAction.Action9 }
        ],

        #endregion
    ];
}