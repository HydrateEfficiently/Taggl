export const LoadStatus = {
    Pending: 1,
    Loading: 2,
    Loaded: 3,
    Failed: 4
};

export function createLoadStatusContainer(value) {
    return { value };
}