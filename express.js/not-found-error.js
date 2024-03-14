class NotFoundError extends Error {
  constructor (options) {
    const { type, id, url } = options
    super()

    this.url = url
    this.message = `No ${type} with id ${id} could not be found.`
  }
}

module.exports = NotFoundError