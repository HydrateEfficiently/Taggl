const GuidLength = 32;

export function isEmpty(guid) {
    if (!guid) return true;
    let normalizedGuid = guid.replace(/-/g, '');
    let emptyGuid = '0'.repeat(GuidLength);
    return normalizedGuid === emptyGuid;
}