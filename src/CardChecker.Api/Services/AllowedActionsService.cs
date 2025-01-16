public class AllowedActionsService
{
    public IEnumerable<CardAction> CheckAllowedActions(CardDetails card)
    {
        foreach (CardAction cardAction in Enum.GetValues(typeof(CardAction)))
        {
            if (IsActionAllowed((cardAction, card.CardType, card.CardStatus, card.IsPinSet)))
            {
                yield return cardAction;
            };
        }
    }

    private static bool IsActionAllowed(
        (CardAction Action, CardType CardType, CardStatus CardStatus, bool IsPinSet) actionForCard
    ) => actionForCard switch
    {
        { Action: CardAction.Action1, CardType: _, CardStatus: CardStatus.Active, IsPinSet: _ } => true,
        { Action: CardAction.Action2, CardType: _, CardStatus: CardStatus.Inactive, IsPinSet: _ } => true,
        { Action: CardAction.Action3, CardType: _, CardStatus: _, IsPinSet: _ } => true,
        { Action: CardAction.Action4, CardType: _, CardStatus: _, IsPinSet: _ } => true,
        { Action: CardAction.Action5, CardType: CardType.Credit, CardStatus: _, IsPinSet: _ } => true,
        {
            Action: CardAction.Action6,
            CardType: _,
            CardStatus: CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active or CardStatus.Blocked,
            IsPinSet: true
        } => true,
        {
            Action: CardAction.Action7,
            CardType: _,
            CardStatus: CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active,
            IsPinSet: false
        } => true,
        {
            Action: CardAction.Action7,
            CardType: _,
            CardStatus: CardStatus.Blocked,
            IsPinSet: true
        } => true,
        {
            Action: CardAction.Action8,
            CardType: _,
            CardStatus: CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active or CardStatus.Blocked,
            IsPinSet: _
        } => true,
        {
            Action: CardAction.Action9,
            CardType: _,
            CardStatus: _,
            IsPinSet: _
        } => true,
        {
            Action: CardAction.Action10,
            CardType: _,
            CardStatus: CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active,
            IsPinSet: _,
        } => true,
        {
            Action: CardAction.Action11,
            CardType: _,
            CardStatus: CardStatus.Inactive or CardStatus.Active,
            IsPinSet: _
        } => true,
        {
            Action: CardAction.Action12,
            CardType: _,
            CardStatus: CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active,
            IsPinSet: _
        } => true,
        {
            Action: CardAction.Action13,
            CardType: _,
            CardStatus: CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active,
            IsPinSet: _
        } => true,
        _ => false
    };
}
