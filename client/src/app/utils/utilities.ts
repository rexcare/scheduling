/**
 * Returns the first value associated to the given search parameter.
 */
export function getUrlParamValue(param: string): string {
    const url = document.location.search || document.location.href;
    let urlParams = new URLSearchParams(url.substring(1));
    return urlParams.get(param) || '';
}
