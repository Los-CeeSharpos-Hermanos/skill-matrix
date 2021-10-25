
export enum ColumnStyle {
    JoinedArray,
    SimpleText
}

export interface IExpandableTableColumn {
    id: string,
    name: string,
    columnStyle: ColumnStyle;
}
