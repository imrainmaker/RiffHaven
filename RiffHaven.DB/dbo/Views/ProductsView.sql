CREATE VIEW ProductsView AS
SELECT
    P.Id_Products,
    P.Model,
    P.Description,
    P.Stock,
    P.Price,
    G.Id_Guitar,
    T.Tremolo,
    PU.Pickup,
    S.Scale,
    F.Frets,
    C.Color,
    ST.Style,
    B.Brand,
    WB.wood AS BodyWood,
    WN.wood AS NeckWood,
    WT.wood AS TopWood,
    WF.wood AS FretboardWood
FROM
    Products P
    JOIN Guitar G ON P.Id_Guitar = G.Id_Guitar
    LEFT JOIN Tremolo T ON G.Id_Tremolo = T.Id_Tremolo
    JOIN Pickups PU ON G.Id_Pickups = PU.Id_Pickups
    JOIN Scales S ON G.Id_Scales = S.Id_Scales
    JOIN Frets F ON G.Id_Frets = F.Id_Frets
    JOIN Colors C ON G.Id_Colors = C.Id_Colors
    JOIN Styles ST ON G.Id_Styles = ST.Id_Styles
    JOIN Brands B ON G.Id_Brands = B.Id_Brands
    JOIN Woods WB ON G.Body = WB.Id_Woods
    JOIN Woods WN ON G.Neck = WN.Id_Woods
    JOIN Woods WT ON G.[Top] = WT.Id_Woods
    JOIN Woods WF ON G.Fretboards = WF.Id_Woods;