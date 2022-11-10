export class NavItem {
    constructor(
        public displayName: string,
        public disabled: boolean,
        public iconName: string,
        public route: string,
        public children: NavItem[] = []
    ) { }
}