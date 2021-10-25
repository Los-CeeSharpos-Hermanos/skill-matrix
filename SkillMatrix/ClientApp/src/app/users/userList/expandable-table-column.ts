
export enum ColumnStyle {
    Chips,
    Text
}

export interface IExpandableTableColumn {
    id: string,
    name: string,
    columnStyle: ColumnStyle;
}
